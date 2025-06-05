using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ItemType
{
	Level,
	Car
}
namespace ALIyerEdon
{
	public class ItemSelect : MonoBehaviour
	{

		// Item type , Level or Car
		public ItemType itemType;

		// Current,Prev and next button images + Items icon
		[Header("Icons")]
		public Sprite[] itemIcons;
		public Image currentItemImage;
		public Image prevItemImage;
		public Image nextItemImage;


		// We used animator to animated current item when selected
		[Header("Current Item Animation")]
		public Animator currentAnimator;

		// play error sound clip when player coins is not enough, OK sound clip when player has enough money and buy item then
		[Header("Sounds")]
		public AudioSource audioSource;
		public AudioClip okClip;
		public AudioClip errorClip;

		// Display cuurent item an total coins
		[Header("Texts")]
		public Text CurentValue;
		public Text coinsTXT;

		// Activate these windows when we need them
		[Header("Windows")]
		public GameObject shopOffer;
		public GameObject lockIcon;
		public GameObject nextMen;

		// Internal usage
		int id;
		bool canAnim;
		bool animaState;

		// List of the items price
		public int[] itemsPrice;

		void Start()
		{

			// Display total coins on start
			coinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();

			// Read last selected item ID
			if (itemType == ItemType.Car)
				id = PlayerPrefs.GetInt("CarID");
			if (itemType == ItemType.Level)
				id = PlayerPrefs.GetInt("LevelID");

			// Update current selected image
			currentItemImage.sprite = itemIcons[id];

			// Select last selected item by default
			if (id != 0)
			{
				PrevCar();
				NextCar();
			}
			else
			{
				NextCar();
				PrevCar();
			}

			// Internal usage
			canAnim = true;

			// Check current item is unlocked?
			if (itemType == ItemType.Car)
			{

				if (PlayerPrefs.GetInt("Car" + id.ToString()) != 3)
					lockIcon.SetActive(true);
				else
					lockIcon.SetActive(false);
			}
			if (itemType == ItemType.Level)
			{

				if (PlayerPrefs.GetInt("Level" + id.ToString()) != 3)
					lockIcon.SetActive(true);
				else
					lockIcon.SetActive(false);
			}

			// Update item prices
			CurentValue.text = itemsPrice[id].ToString();

		}


		// public function used in ui button to select next car
		public void NextCar()
		{

			if (id < itemIcons.Length - 1)
			{
				id++;
				if (canAnim)
					PlayAnim();
				audioSource.clip = okClip;
				audioSource.Play();
			}
			currentItemImage.sprite = itemIcons[id];

			if (id < itemIcons.Length - 1)
			{
				prevItemImage.color = new Color(1f, 1f, 1f, 1f);
				nextItemImage.sprite = itemIcons[id + 1];
				prevItemImage.sprite = itemIcons[id - 1];

			}
			else
			{
				nextItemImage.sprite = null;
				nextItemImage.color = new Color(0, 0, 0, 0);
				prevItemImage.sprite = itemIcons[id - 1];
			}

			if (itemType == ItemType.Car)
				PlayerPrefs.SetInt("CarID", id);
			if (itemType == ItemType.Level)
				PlayerPrefs.SetInt("LevelID", id);



			if (itemType == ItemType.Car)
			{
				if (PlayerPrefs.GetInt("Car" + id.ToString()) != 3)
					lockIcon.SetActive(true);
				else
					lockIcon.SetActive(false);
			}
			if (itemType == ItemType.Level)
			{
				if (PlayerPrefs.GetInt("Level" + id.ToString()) != 3)
					lockIcon.SetActive(true);
				else
					lockIcon.SetActive(false);
			}


			CurentValue.text = itemsPrice[id].ToString();
		}

		// public function used in ui button to select prev car
		public void PrevCar()
		{

			if (id > 0)
			{
				--id;
				if (canAnim)
					PlayAnim();

				audioSource.clip = okClip;
				audioSource.Play();
			}
			currentItemImage.sprite = itemIcons[id];
			if (id > 0)
			{
				nextItemImage.color = new Color(1f, 1f, 1f, 1f);
				prevItemImage.sprite = itemIcons[id - 1];
				nextItemImage.sprite = itemIcons[id + 1];

			}
			else
			{
				prevItemImage.sprite = null;
				prevItemImage.color = new Color(0, 0, 0, 0);
				nextItemImage.sprite = itemIcons[id + 1];
			}

			if (itemType == ItemType.Level)
				PlayerPrefs.SetInt("LevelID", id);
			if (itemType == ItemType.Car)
				PlayerPrefs.SetInt("CarID", id);


			if (itemType == ItemType.Level)
			{
				if (PlayerPrefs.GetInt("Level" + id.ToString()) != 3)
					lockIcon.SetActive(true);
				else
					lockIcon.SetActive(false);
			}

			if (itemType == ItemType.Car)
			{
				if (PlayerPrefs.GetInt("Car" + id.ToString()) != 3)
					lockIcon.SetActive(true);
				else
					lockIcon.SetActive(false);
			}


			CurentValue.text = itemsPrice[id].ToString();
		}


		// Play animation when player select next or prev item
		void PlayAnim()
		{
			animaState = !animaState;
			if (animaState)
				currentAnimator.CrossFade("Next", .003f);
			else
				currentAnimator.CrossFade("Prev", .003f);

		}


		// Select current item and go to the next menu
		public void SelectCurrent()
		{
			if (itemType == ItemType.Level)
			{
				if (PlayerPrefs.GetInt("Level" + id.ToString()) == 3)
				{
					gameObject.SetActive(false);
					nextMen.SetActive(true);
					PlayerPrefs.SetInt("SelectedLevel", id);
				}
				else
				{
					audioSource.clip = errorClip;
					audioSource.Play();
				}
			}

			if (itemType == ItemType.Car)
			{
				if (PlayerPrefs.GetInt("Car" + id.ToString()) == 3)
				{
					gameObject.SetActive(false);
					nextMen.SetActive(true);
					PlayerPrefs.SetInt("SelectedCar", id);
				}
				else
				{
					audioSource.clip = errorClip;
					audioSource.Play();
				}
			}
		}



		// Public function used in current selected button (ui button ) 
		public void Buy()
		{

			if (itemType == ItemType.Level)
			{
				if (PlayerPrefs.GetInt("Level" + id.ToString()) != 3)
				{
					if (PlayerPrefs.GetInt("Coins") >= itemsPrice[id])
					{
						PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - itemsPrice[id]);
						PlayerPrefs.SetInt("Level" + id.ToString(), 3);
						lockIcon.SetActive(false);
						coinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
					}
					else
						shopOffer.SetActive(true);
				}

			}

			if (itemType == ItemType.Car)
			{
				if (PlayerPrefs.GetInt("Car" + id.ToString()) != 3)
				{
					if (PlayerPrefs.GetInt("Coins") >= itemsPrice[id])
					{
						PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - itemsPrice[id]);
						PlayerPrefs.SetInt("Car" + id.ToString(), 3);
						lockIcon.SetActive(false);
						coinsTXT.text = PlayerPrefs.GetInt("Coins").ToString();
					}
					else
						shopOffer.SetActive(true);
				}

			}

		}
	}
}