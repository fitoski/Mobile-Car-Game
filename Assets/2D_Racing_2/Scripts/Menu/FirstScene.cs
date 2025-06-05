using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ALIyerEdon
{
	public class FirstScene : MonoBehaviour
	{



		public string nameLevel;

		void Start()
		{
			SceneManager.LoadSceneAsync(nameLevel);
		}
	}
}