using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ALIyerEdon
{
	public class CarSelect : MonoBehaviour
	{

		// Store car current id
		[HideInInspector] public int id;

		[Header("Coins Text")]
		// Show total coins 
		public Text CoinsTXT;

		[Header("Cars price")]
		// List of the cars prices
		public int[] priceList;
		public Text[] levelTexts;

		[Header("Cars lock")]
		// Car's lock
		public GameObject[] locks;

		[Header("Shop Window")]
		public GameObject shop;

		[Header("Menus")]
		public GameObject nextMenu, currentMenu;


		public void SetCarID(int num)
		{
			id = num;

		}

		void Start()
		{

			for (int a = 0; a < locks.Length; a++)
			{

				if (PlayerPrefs.GetInt("Car" + a.ToString()) == 3)  // 3 => true | 0 => false
					locks[a].SetActive(false);
			}
		}

		public void Buy(int num)
		{
			if (PlayerPrefs.GetInt("Car" + id.ToString()) == 3)
			{     // 3 => true | 0 => false

				PlayerPrefs.SetInt("SelectedCar", num);
				nextMenu.SetActive(true);
				currentMenu.SetActive(false);

			}
			else
			{
				if (PlayerPrefs.GetInt("Coins") >= priceList[num])
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - priceList[num]);
					PlayerPrefs.SetInt("Car" + num.ToString(), 3);
					locks[num].SetActive(false);
					CoinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
				}
				else
					shop.SetActive(true);
			}

		}



		public void Select()
		{
			if (PlayerPrefs.GetInt("Car" + id.ToString()) == 3)
			{     // 3 => true | 0 => false

				PlayerPrefs.SetInt("SelectedCar", id);
				nextMenu.SetActive(true);
				currentMenu.SetActive(false);

			}

		}

	}
}