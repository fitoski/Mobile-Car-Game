using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class StartPoint : MonoBehaviour
	{

		public GameObject[] cars;

		void Start()
		{
			Instantiate(cars[PlayerPrefs.GetInt("SelectedCar")], transform.position, transform.rotation);
		}
	}
}