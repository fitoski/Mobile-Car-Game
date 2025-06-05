using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ALIyerEdon
{
	public class SettingsMenu : MonoBehaviour
	{


		public Slider engineVolume, musicVolume;

		public Toggle showDistance, coinAudio;

		public InputField cheatBox;

		public Text currentResolution, currentQuality;

		public bool activateCheats;

		void Start()
		{


			if (PlayerPrefs.GetInt("ShowDistance") == 3)  // 3=> true - 0 => false
				showDistance.isOn = true;
			else
				showDistance.isOn = false;

			if (PlayerPrefs.GetInt("CoinAudio") == 3)  // 3=> true - 0 => false
				coinAudio.isOn = true;
			else
				coinAudio.isOn = false;

			if (PlayerPrefs.GetInt("Resolution") == 0)
				currentResolution.text = "500";
			if (PlayerPrefs.GetInt("Resolution") == 1)
				currentResolution.text = "720P";
			if (PlayerPrefs.GetInt("Resolution") == 2)
				currentResolution.text = "1080P";

			if (PlayerPrefs.GetInt("Quality") == 0)
				currentQuality.text = "Low";
			if (PlayerPrefs.GetInt("Quality") == 3)
				currentQuality.text = "Medium";
			if (PlayerPrefs.GetInt("Quality") == 5)
				currentQuality.text = "High";

			engineVolume.value = PlayerPrefs.GetFloat("EngineVolume");
			musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");


		}


		public void SetEngineVolume()
		{

			PlayerPrefs.SetFloat("EngineVolume", engineVolume.value);
		}

		public void SetMusicVolume()
		{

			PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
		}

		public void SetShowDistance()
		{

			StartCoroutine(saveDistance());
		}


		IEnumerator saveDistance()
		{

			yield return new WaitForEndOfFrame();

			if (showDistance.isOn)
				PlayerPrefs.SetInt("ShowDistance", 3);// 3=> true - 0 => false
			else
				PlayerPrefs.SetInt("ShowDistance", 0);// 3=> true - 0 => false

		}

		public void SetCoinAudio()
		{

			StartCoroutine(saveCoinAudio());
		}


		IEnumerator saveCoinAudio()
		{

			yield return new WaitForEndOfFrame();

			if (coinAudio.isOn)
				PlayerPrefs.SetInt("CoinAudio", 3);// 3=> true - 0 => false
			else
				PlayerPrefs.SetInt("CoinAudio", 0);// 3=> true - 0 => false

		}

		public void SetResolution(int val)
		{

			PlayerPrefs.SetInt("Resolution", val);

			if (PlayerPrefs.GetInt("Resolution") == 0)
				currentResolution.text = "500";
			if (PlayerPrefs.GetInt("Resolution") == 1)
				currentResolution.text = "720P";
			if (PlayerPrefs.GetInt("Resolution") == 2)
				currentResolution.text = "1080P";

		}


		public void SetQualityLevel(int val)
		{

			PlayerPrefs.SetInt("Quality", val);

			if (PlayerPrefs.GetInt("Quality") == 0)
				currentQuality.text = "Low";
			if (PlayerPrefs.GetInt("Quality") == 3)
				currentQuality.text = "Medium";
			if (PlayerPrefs.GetInt("Quality") == 5)
				currentQuality.text = "High";

			QualitySettings.SetQualityLevel(val);

		}
		public void EnterCheat()
		{
			if (activateCheats)
			{
				if (cheatBox.text == "DeveloperCoins-10000")
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10000);
				if (cheatBox.text == "DeveloperCoins-100000")
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100000);
				if (cheatBox.text == "DeveloperCoins-1000000")
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1000000);

				if (cheatBox.text == "DeveloperLevels-Unlock1")
					PlayerPrefs.SetInt("Level1", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock2")
					PlayerPrefs.SetInt("Level2", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock3")
					PlayerPrefs.SetInt("Level3", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock4")
					PlayerPrefs.SetInt("Level4", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock5")
					PlayerPrefs.SetInt("Level5", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock6")
					PlayerPrefs.SetInt("Level6", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock7")
					PlayerPrefs.SetInt("Level7", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock8")
					PlayerPrefs.SetInt("Level8", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock9")
					PlayerPrefs.SetInt("Level9", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperLevels-Unlock10")
					PlayerPrefs.SetInt("Level10", 3);// 3=> true - 0 => false

				if (cheatBox.text == "DeveloperLevels-UnlockAll")
				{

					for (int a = 0; a < 100; a++)
						PlayerPrefs.SetInt("Level" + a.ToString(), 3);// 3=> true - 0 => false
				}

				if (cheatBox.text == "DeveloperCars-Unlock1")
					PlayerPrefs.SetInt("Car1", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock2")
					PlayerPrefs.SetInt("Car2", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock3")
					PlayerPrefs.SetInt("Car3", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock4")
					PlayerPrefs.SetInt("Car4", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock5")
					PlayerPrefs.SetInt("Car5", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock6")
					PlayerPrefs.SetInt("Car6", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock7")
					PlayerPrefs.SetInt("Car7", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock8")
					PlayerPrefs.SetInt("Car8", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock9")
					PlayerPrefs.SetInt("Car9", 3);// 3=> true - 0 => false
				if (cheatBox.text == "DeveloperCars-Unlock10")
					PlayerPrefs.SetInt("Car10", 3);// 3=> true - 0 => false

				if (cheatBox.text == "DeveloperCars-UnlockAll")
				{

					for (int a = 0; a < 100; a++)
						PlayerPrefs.SetInt("Car" + a.ToString(), 3);// 3=> true - 0 => false
				}


			}
		}
	}
}