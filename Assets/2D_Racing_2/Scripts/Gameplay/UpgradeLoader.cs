using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class UpgradeLoader : MonoBehaviour
	{


		[Space(4)]
		[Header("Enter Car ID")]
		// Car id to loadhis upgrade
		public int carID = 0;


		[Space(3)]
		[Header("Assign Car Controller")]
		// Get car controller
		public CarController carController;

		[Space(3)]
		[Header("Upgrade values")]
		// How much upgrade car for each level
		public float[] engineUpgrade;
		public float[] speedUpgrade;
		public float[] rotateUpgrade;
		public float[] fuelUpgrade;

		[Space(3)]
		[Header("Log Debug Messages")]
		public bool debug;

		GameManager manager;

		void Awake()
		{

			// Read from upgrade menu
			carController.motorPower = engineUpgrade[PlayerPrefs.GetInt("Engine" + carID.ToString())];
			carController.maxSpeed = speedUpgrade[PlayerPrefs.GetInt("Speed" + carID.ToString())];

			// Suspension upgrade used as car rotate force on air (when isgrounded is false in CarController script)
			carController.RotateForce = rotateUpgrade[PlayerPrefs.GetInt("Suspension" + carID.ToString())];

#if UNITY_EDITOR
			if (debug)
			{
				Debug.Log("Engine Level : " + PlayerPrefs.GetInt("Engine" + carID.ToString()).ToString());
				Debug.Log("Speed Level : " + PlayerPrefs.GetInt("Speed" + carID.ToString()).ToString());
				Debug.Log("Rotate Level : " + PlayerPrefs.GetInt("Suspension" + carID.ToString()).ToString());
			}
#endif

			manager = GameObject.FindObjectOfType<GameManager>();


			manager.FuelTime = fuelUpgrade[PlayerPrefs.GetInt("Fuel" + carID.ToString())];
		}

	}


}