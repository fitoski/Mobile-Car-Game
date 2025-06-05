using UnityEngine;  
using System.Collections;

namespace ALIyerEdon
{
	public class CarController : MonoBehaviour
	{


		// Car rigidbody COM
		public Transform centerOfMass;

		// Wheel motor for drive the car based on wheelJoint 2D
		JointMotor2D[] motorBacks;

		// Which wheel to drive with that?
		public WheelJoint2D[] motorWheels;

		// Store car speed
		public float speed;

		// Store is grounded based on the distance of the ground
		bool isGrounded;

		// How much distance of the ground means cars is grounded? answer=> less than 2.1f
		public float groundDistance = 2.1f;

		// Motor power, Brake power and deceleration speed
		public float motorPower = 1400f,
		brakePower = -14f,
		 decelerationSpeed = 0.3f;

		// Car max speed
		public float maxSpeed = 14f;

		// inrenal usage
		float motorTemp;

		// Can rotate option. be true value when car is on the fly
		bool canRotate = false;

		// Rotate force on the  fly 
		public float RotateForce = 140f;

		[HideInInspector] public AudioSource EngineSoundS;

		public bool isMobile;

		public ParticleSystem wheelParticle;

		// Internal usage
		float powerTemp;
		ParticleSystem.EmissionModule em, emSmoke;

		public Transform particlePosition;


		public bool useSmoke;
		public ParticleSystem smoke;
		public float smokeTargetSpeed = 17f;

		public float cameraDistance = 15f;


		void Awake()
		{
			Vector3 posCamera;
			posCamera = Camera.main.transform.position;
			Camera.main.transform.position = new Vector3(posCamera.x, posCamera.y, -cameraDistance);
		}

		void Start()
		{


			// Set car rigidbody's COM
			GetComponent<Rigidbody2D>().centerOfMass = centerOfMass.transform.localPosition;

			motorBacks = new JointMotor2D[motorWheels.Length];

			//motorWheels = GetComponentsInChildren<WheelJoint2D>();

			// Starting with WheelJoint2D motor
			for (int a = 0; a < motorWheels.Length; a++)
				motorBacks[a] = motorWheels[a].motor;

			// Cast a ray to find isGrounded 
			StartCoroutine(RaycCast());

			EngineSoundS = GetComponent<AudioSource>();

			powerTemp = motorPower;

			try
			{
				em = wheelParticle.emission;
				em.enabled = false;
			}
			catch { }
			if (smoke)
			{
				emSmoke = smoke.emission;
				emSmoke.enabled = false;
			}



		}

		float currentSpeed;
		//float maxspeed = 300f;

		void FixedUpdate()
		{

			// speed limiter based on max speed limit value
			if (speed > maxSpeed)
				motorPower = 0;
			else
				motorPower = powerTemp;

			// Moving forward
			if (Input.GetAxis("Horizontal") > 0 || HoriTemp > 0)
			{

				// Add force to car back wheel
				if (isGrounded)
				{
					for (int a = 0; a < motorWheels.Length; a++)
						motorBacks[a].motorSpeed = Mathf.Lerp(motorBacks[a].motorSpeed, -motorPower, Time.deltaTime * 1.4f);
				}

				// Wheel particles
				if (isGrounded)
				{
					if (speed < 4.3f)
					{

						if (wheelParticle)
							wheelParticle.transform.position = particlePosition.position;

						if (wheelParticle)
							em.enabled = true;

					}
					else
					{
						if (wheelParticle)
							em.enabled = false;
					}
				}
				else
				{
					if (wheelParticle)
						em.enabled = false;
				}

			}
			else
			{// Moving backward
				if (Input.GetAxis("Horizontal") < 0 || HoriTemp < 0)
				{
					if (speed < -maxSpeed)
					{
						if (isGrounded)
						{
							for (int a = 0; a < motorWheels.Length; a++)
								motorBacks[a].motorSpeed = Mathf.Lerp(motorBacks[a].motorSpeed, 0, Time.deltaTime * 3f);
						}
					}
					else
					{
						if (isGrounded)
						{
							for (int a = 0; a < motorWheels.Length; a++)
								motorBacks[a].motorSpeed = Mathf.Lerp(motorBacks[a].motorSpeed, motorPower, Time.deltaTime * 1.4f);
						}
					}

				}
				else
				{// Releasing car throttle and brake
					if (isGrounded)
					{
						for (int a = 0; a < motorWheels.Length; a++)
							motorBacks[a].motorSpeed = Mathf.Lerp(motorBacks[a].motorSpeed, 0, Time.deltaTime * decelerationSpeed);
					}
				}

			}

			// Update WheelJoint2D motor inputs

			for (int a = 0; a < motorWheels.Length; a++)
				motorWheels[a].motor = motorBacks[a];


			Rotate();

#if UNITY_EDITOR
			EngineSoundEditor();
#else
		EngineSoundMobile (); 
#endif

			if (!isMobile)
				HoriTemp = Input.GetAxis("Horizontal");

			if (useSmoke)
			{
				if (Input.GetAxis("Horizontal") > 0 || HoriTemp > 0)
				{
					if (speed < smokeTargetSpeed)
						emSmoke.enabled = true;
					else
						emSmoke.enabled = false;
				}
				else
					emSmoke.enabled = false;
			}
		}


		void LateUpdate()
		{

			// Get car speed
			speed = GetComponent<Rigidbody2D>().linearVelocity.magnitude;
			if (Input.GetAxis("Horizontal") < 0 || HoriTemp < 0)
				speed = -speed;
		}

		// Rotate car on air based on speed
		void Rotate()
		{
			//based on player forward input(Like Hill Climb Racing game)
			if (Input.GetAxis("Horizontal") > 0 || HoriTemp > 0)
			{


				GetComponent<Rigidbody2D>().AddTorque(RotateForce);
			}
			else
			{

				if (Input.GetAxis("Horizontal") < 0.0f || HoriTemp < 0)
					GetComponent<Rigidbody2D>().AddTorque(-RotateForce);
			}
		}

		// Raycast body to find that car is on the ground or not
		IEnumerator RaycCast()
		{

			while (true)
			{

				yield return new WaitForEndOfFrame();

				RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1000);

				float distance = Mathf.Abs(hit.point.y - transform.position.y);


				if (distance < groundDistance)
					isGrounded = true;
				else
					isGrounded = false;

				canRotate = !isGrounded;

			}

		}

		// Engine sound system

		public float Multiplyer = 3f;
		public float minP = 1f;
		public float maxP = 2.4f;
		[HideInInspector] public float HoriTemp;

		public void EngineSoundMin()
		{
			if (EngineSoundS.pitch > minP)
				EngineSoundS.pitch -= 1.4f * Time.deltaTime;
		}

		public void EngineSoundMobile()
		{

			if (speed < 40)
			{
				EngineSoundS.pitch = Mathf.Lerp(EngineSoundS.pitch, Mathf.Clamp(Mathf.Abs(HoriTemp) * Multiplyer, minP, maxP), Time.deltaTime * 5);
			}
			else
			{
				EngineSoundS.pitch = Mathf.Lerp(EngineSoundS.pitch, Mathf.Clamp(Mathf.Abs(HoriTemp) * Multiplyer, minP, maxP), Time.deltaTime * 5);
			}
		}

		public void EngineSoundEditor()
		{

			if (speed < 40)
			{
				EngineSoundS.pitch = Mathf.Lerp(EngineSoundS.pitch, Mathf.Clamp(Mathf.Abs(Input.GetAxis("Horizontal")) * Multiplyer, minP, maxP), Time.deltaTime * 5);
			}
			else
			{
				EngineSoundS.pitch = Mathf.Lerp(EngineSoundS.pitch, Mathf.Clamp(Mathf.Abs(Input.GetAxis("Horizontal")) * Multiplyer, minP, maxP), Time.deltaTime * 5);
			}
		}

		// Vehicle input system
		//this is public function for car Acceleration UI Button
		public void Acceleration()
		{
			HoriTemp = 1f;
		}
		//this is public function for car Brake\Backward UI Button
		public void Brake()
		{
			HoriTemp = -1f;
		}


		//this is for when player both release Brake or Acceleration button
		public void GasBrakeRelease()
		{

			HoriTemp = 0;


		}
	}
}