using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class FinishTrigger : MonoBehaviour
	{

		// Use this for initialization
		public GameObject finishMenu;

		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void OnTriggerEnter(Collider col)
		{

			if (col.CompareTag("Player"))
			{
				finishMenu.SetActive(true);
			}

		}
	}
}