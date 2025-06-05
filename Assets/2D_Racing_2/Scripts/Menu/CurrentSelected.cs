using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace ALIyerEdon
{
	public class CurrentSelected : MonoBehaviour
	{

		[Header("Button ID")]
		public int id;

		[Header("Center point")]
		public Transform centerPoint;

		float Dist;

		[Header("Car and Level Select Components")]
		public CarSelect carSelect;

		public LevelSelect levelSelect;



		Vector3 vec;


		bool started;

		void Update()
		{

			Dist = Vector3.Distance(transform.position, centerPoint.position);

			if (Dist < 100f)
			{

				if (carSelect)
					carSelect.id = id;

				if (levelSelect)
					levelSelect.id = id;
			}
		}
	}
}