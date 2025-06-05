using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using ALIyerEdon;
using System.Reflection;

namespace Tests.EditMode
{
    public class UpgradeTests
    {
        [Test]
        public void SuspensionUpgrade_UpdatesPriceLabel()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Coins", 500);
            PlayerPrefs.SetInt("Suspension0", 0);

            var go = new GameObject("UpgradeGO");
            var upgrade = go.AddComponent<Upgrade>();

            upgrade.suspensionPrice = new int[] { 100, 200 };
            upgrade.speedPrice = new int[] { 1, 1 }; // length needed by method
            upgrade.enginePrice = new int[0];
            upgrade.fuelPrice = new int[0];

            upgrade.CoinsTXT = new GameObject("CoinsTXT").AddComponent<Text>();
            upgrade.SuspensionTXT = new GameObject("SuspensionTXT").AddComponent<Text>();
            upgrade.priceSuspensionTXT = new GameObject("PriceSuspensionTXT").AddComponent<Text>();
            upgrade.Shop = new GameObject("Shop");
            upgrade.audioSource = go.AddComponent<AudioSource>();
            upgrade.Buy = AudioClip.Create("buy", 1, 1, 44100, false);

            // set private id field
            typeof(Upgrade).GetField("id", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(upgrade, 0);

            upgrade.SuspensionUpgrade();

            Assert.AreEqual("200 $", upgrade.priceSuspensionTXT.text);
            Assert.AreEqual(1, PlayerPrefs.GetInt("Suspension0"));
        }
    }
}
