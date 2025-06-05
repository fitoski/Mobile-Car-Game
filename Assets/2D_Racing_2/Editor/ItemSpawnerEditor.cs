using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ALIyerEdon
{
	[CustomEditor(typeof(ItemSpawner))]
	public class ItemSpawnerEditor : Editor
	{
		private ItemSpawner script;

		int rand1, rand2;
		int id;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			script = (ItemSpawner)target;


			EditorGUILayout.Space();

			GUI.color = Color.green;
			EditorGUILayout.Space();

			EditorGUILayout.HelpBox("Automatic Item Spawner", MessageType.None);

			EditorGUILayout.Space();
			GUI.color = Color.white;


			//---------------------------------------------------------------------------
			EditorGUILayout.PropertyField(serializedObject.FindProperty("itemName"),
				new GUIContent("Item Name", "Enter item your name"), true);
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("Items"),
				new GUIContent("Items", "Drag youre items"), true);
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("mover"),
				new GUIContent("Mover", "Drag mover gameobject"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("distance"),
				new GUIContent("Totall Distance", "Distance between each item set"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("betweenItems"),
				new GUIContent("Between Items", "How much distance between two items?"), true);
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("itemsDurationOnEachSet"),
				new GUIContent("Sets Length", ""), true);

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("betweenEachItemSet"),
				new GUIContent("Between Sets Distance", ""), true);

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("roadAlign"),
				new GUIContent("Align On Road Direction", ""), true);



			if (GUILayout.Button("Start", GUILayout.Height(40)))
			{

				GameObject Items = new GameObject(script.itemName + "s");
				Items.transform.parent = script.transform;
				//Items = (GameObject)Instantiate (new GameObject ("Coins"), new Vector3 (0, 0, 0), Quaternion.identity);


				for (int a = 0; a < script.distance; a++)
				{
					rand1++;
					rand2 = (int)(Mathf.Floor(script.itemsDurationOnEachSet));
					if (rand1 >= rand2 + 1)
						rand1 = 0;
					if (rand1 >= rand2)
						script.mover.transform.Translate(Vector3.right * script.betweenEachItemSet);
					else
						script.mover.transform.Translate(Vector3.right * script.betweenItems);
					RaycastHit2D hit = Physics2D.Raycast(script.mover.transform.position, -Vector2.up, 430);
					if (hit.collider != null)
					{

						GameObject tem;
						if (script.Items.Length > 1)
						{
							if (script.roadAlign)
								tem = (GameObject)Instantiate(script.Items[(int)(Mathf.Floor(Random.Range(0f, 2.1f)))], new Vector2(hit.point.x, hit.point.y + 1), Quaternion.FromToRotation(Vector3.up, hit.normal));
							else
								tem = (GameObject)Instantiate(script.Items[(int)(Mathf.Floor(Random.Range(0f, 2.1f)))], new Vector2(hit.point.x, hit.point.y + 1), Quaternion.identity);
						}
						else
						{
							if (script.roadAlign)
								tem = (GameObject)Instantiate(script.Items[0], new Vector2(hit.point.x, hit.point.y + 1), Quaternion.FromToRotation(Vector3.up, hit.normal));
							else
								tem = (GameObject)Instantiate(script.Items[0], new Vector2(hit.point.x, hit.point.y + 1), Quaternion.identity);
						}

						id++;
						tem.transform.parent = Items.transform;
						tem.name = script.itemName + " " + id.ToString();
					}
				}
			}

			serializedObject.ApplyModifiedProperties();



		}
	}
}