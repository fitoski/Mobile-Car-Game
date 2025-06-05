using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace ALIyerEdon
{
	public class Pause : MonoBehaviour
	{

		// Use this for initialization
		public GameObject PauseMen;


		public string menuLevelName = "MainMenu";

		public GameObject loading;

		// Update is called once per frame
		public void Pausing()
		{
			AudioListener.volume = 0;
			Camera.main.GetComponent<SmoothFollow2D>().enabled = false;
			Time.timeScale = 0;
			PauseMen.SetActive(true);
		}

		public void Resume()
		{
			AudioListener.volume = 1f;

			Time.timeScale = 1f;
			Camera.main.GetComponent<SmoothFollow2D>().enabled = true;
			PauseMen.SetActive(false);
		}

		public void Retry()
		{
			AudioListener.volume = 1f;
			
			Time.timeScale = 1f;
			if (loading)
				loading.SetActive(true);
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		}

		public void Exit()
		{
			AudioListener.volume = 1f;
			
			if (loading)
				loading.SetActive(true);
			Time.timeScale = 1f;
			SceneManager.LoadSceneAsync(menuLevelName);
		}

	}
}