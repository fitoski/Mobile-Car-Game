using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace ALIyerEdon
{
	public class SettingsLoader : MonoBehaviour
	{

		public GameObject distanceSlider;

		public AudioSource musicVolume, coinAudio;

		public GameObject musicPrefab;

		IEnumerator Start()
		{

			if (PlayerPrefs.GetInt("ShowDistance") == 3)  // 3=> true - 0 => false
				distanceSlider.SetActive(true);
			else
				distanceSlider.SetActive(false);

			if (PlayerPrefs.GetInt("CoinAudio") == 3)  // 3=> true - 0 => false
				coinAudio.volume = 1f;
			else
				coinAudio.volume = 0;

			if (PlayerPrefs.GetInt("Resolution") == 0 || PlayerPrefs.GetInt("Resolution") == 1 || PlayerPrefs.GetInt("Resolution") == 2)
			{
				if (PlayerPrefs.GetInt("Resolution") == 0)
					Screen.SetResolution(900, 506, true);
				if (PlayerPrefs.GetInt("Resolution") == 1)
					Screen.SetResolution(1280, 720, true);
				if (PlayerPrefs.GetInt("Resolution") == 2)
					Screen.SetResolution(1920, 1080, true);

				Camera.main.aspect = 16f / 9f;
			}
			if (PlayerPrefs.GetInt("Loaded") != 3)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				PlayerPrefs.SetInt("Loaded", 3);
			}
			else
				PlayerPrefs.SetInt("Loaded", 7);




			yield return new WaitForEndOfFrame();

			GameObject.FindObjectOfType<CarController>().EngineSoundS.volume = PlayerPrefs.GetFloat("EngineVolume");

			if (!GameObject.Find("LevelMusic(Clone)"))
			{
				GameObject m = (GameObject)Instantiate(musicPrefab, Vector3.zero, Quaternion.identity);
				GameObject.DontDestroyOnLoad(m);
			}


			GameObject.Find("LevelMusic(Clone)").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");

		}
	}


}