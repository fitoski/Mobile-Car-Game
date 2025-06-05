using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class DeadTrigger : MonoBehaviour
	{

		GameManager manager;

		void Start()
		{
			manager = GameObject.FindObjectOfType<GameManager>();
		}

		public bool enter;


		void OnTriggerEnter2D(Collider2D col)
		{
			if (col.tag == "Ground")
			{
				Camera.main.GetComponent<SmoothFollow2D>().enabled = false;
				manager.isDead = true;
				manager.StartDead();
				enter = true;
			}
		}
		void OnTriggerExit2D(Collider2D col)
		{
			if (col.tag == "Ground")
			{
				Camera.main.GetComponent<SmoothFollow2D>().enabled = true;
				manager.isDead = false;
				enter = false;
			}
		}
	}
}