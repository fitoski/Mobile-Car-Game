using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class SmoothFollow2D : MonoBehaviour
	{

		private Vector3 velocity = Vector3.zero;
		Transform target;
		[Space(3)]
		public float startDelay = 0.03f;
		public string targetTag = "Player";
		public float zLimit = 24f;
		public Vector2 position = new Vector2(0.3f, 0.5f);

		float speedFactor;

		Rigidbody2D rigid;

		Vector3 orginalPos;

		public float smoothTime = 3f;
		CarController controller;

		IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			target = GameObject.FindGameObjectWithTag(targetTag).transform;
			rigid = target.GetComponent<Rigidbody2D>();
			orginalPos = transform.position;
			controller = target.GetComponent<CarController>();
		}
		void Update()
		{
			if (target)
			{

				speedFactor = rigid.linearVelocity.magnitude;



				Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
				Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(position.x, position.y, point.z)); //(new Vector3(0.5, 0.5, point.z));

				Vector3 destination = transform.position + delta;

				if (controller.HoriTemp != 0)
				{


					transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.Lerp(transform.position,
						destination, Time.deltaTime * smoothTime * (speedFactor / 10)), ref velocity, 0);


				}
				else
				{


					transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.Lerp(transform.position,
					destination, Time.deltaTime * smoothTime * (speedFactor / 10)), ref velocity, 0);

				}
			}

		}
	}
}