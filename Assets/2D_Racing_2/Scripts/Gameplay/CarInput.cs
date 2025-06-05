using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class CarInput : MonoBehaviour
	{


		[HideInInspector] public CarController carController;

		IEnumerator Start()
		{
			yield return new WaitForSeconds(.3f);
			carController = GameObject.FindObjectOfType<CarController>();
		}

		public void Gas()
		{
			carController.Acceleration();
		}

		public void Brake()
		{
			carController.Brake();
		}

		public void ReleaseGasBrake()
		{
			carController.GasBrakeRelease();
		}
	}
}