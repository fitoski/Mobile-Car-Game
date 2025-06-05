using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ALIyerEdon
{
	public class LevelSelect : MonoBehaviour
	{

		// Store current level id
		[HideInInspector] public int id;

		[Header("Coins Text")]
		// Show total coins 
		public Text CoinsTXT;

		[Header("Levels price")]
		// List of the levels price
		public int[] priceList;
		public Text[] levelTexts;

		[Header("List of the level locks")]
		public GameObject[] locks;

		[Header("Show window")]
		public GameObject shop;

		[Header("Menus")]
		public GameObject nextMenu;
		public GameObject currentMenu;

		public void SetLevelID(int num)

		{
			id = num;

		}

		void Start()
		{

			// Hide unlocked level locks on start
			PlayerPrefs.SetInt("Level0", 3);// 3 => true | 0 => false
			for (int a = 0; a < locks.Length; a++)
			{

				if (PlayerPrefs.GetInt("Level" + a.ToString()) == 3)  // 3 => true | 0 => false
					locks[a].SetActive(false);

				levelTexts[a].text = priceList[a].ToString();
			}
		}

		// Public function for buy selected level by his id
		public void Buy(int num)
		{
			if (PlayerPrefs.GetInt("Level" + id.ToString()) == 3)
			{     // 3 => true | 0 => false

				PlayerPrefs.SetInt("SelectedLevel", id);
				nextMenu.SetActive(true);
				currentMenu.SetActive(false);

			}
			else
			{
				if (PlayerPrefs.GetInt("Coins") >= priceList[num])
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - priceList[num]);
					PlayerPrefs.SetInt("Level" + num.ToString(), 3);
					locks[num].SetActive(false);
					CoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
				}
				else
					shop.SetActive(true);
			}

		}

		public void Select()
		{
			if (PlayerPrefs.GetInt("Level" + id.ToString()) == 3)
			{     // 3 => true | 0 => false


				PlayerPrefs.SetInt("SelectedLevel", id);
				nextMenu.SetActive(true);

				//sceneLoading.loadNextScene ("Level"+PlayerPrefs.GetInt ("SelectedLevel").ToString());

				currentMenu.SetActive(false);


			}

		}

	}
}