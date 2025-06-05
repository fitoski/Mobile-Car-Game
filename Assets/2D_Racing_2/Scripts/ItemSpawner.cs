using UnityEngine;
using System.Collections;
namespace ALIyerEdon
{
	public class ItemSpawner : MonoBehaviour
	{

		// List of the randomizing items
		public GameObject[] Items;
		public GameObject parent;
		public GameObject mover;
		public float distance = 1000f;

		public string itemName = "Item";
		public float betweenItems = 1.4f;
		public float betweenEachItemSet = 14f;
		public float itemsDurationOnEachSet = 14f;

		public bool roadAlign;
	}
}