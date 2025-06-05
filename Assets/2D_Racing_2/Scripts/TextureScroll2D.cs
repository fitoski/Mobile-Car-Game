using UnityEngine;
using System.Collections;

namespace ALIyerEdon
{
	public class TextureScroll2D : MonoBehaviour
	{

		float scrollSpeed = .5f;
		public float offset, OffsetReducer;
		float rotate;
		public bool canMove;
		Rigidbody2D vc;
		bool Started;
		public Transform player;

		IEnumerator Start()
		{


			yield return new WaitForSeconds(.00003f);
			if (!player)
				vc = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
			else
				vc = player.GetComponent<Rigidbody2D>();
			Started = true;
		}

		void Update()
		{
			if (Started)
			{
				offset += (Time.deltaTime * vc.linearVelocity.x) / OffsetReducer;
				GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
			}
		}
	}
}