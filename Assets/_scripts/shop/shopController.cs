using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour {

	// Prefab
	public GameObject shopUpgrade;
	// Placed from scene
	public GameObject shopPlacements;
	private GameObject shop;
	private shopHolder sH;

	// Putting upgrades
	private shopStorage sS;
	public GameObject casinoButton;
	public GameObject trophyButton;

	// Use this for initialization
	void Start () {
		// shopPlacements = GameObject.FindGameObjectWithTag ("shopMenu").transform.GetChild (2).gameObject;
		sH = GameObject.FindGameObjectWithTag("shopHolder").GetComponent<shopHolder>();
		shop = GameObject.FindGameObjectWithTag ("shop").gameObject;
		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage> ();

		showUpgrades ();
		applyUpgrades ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showUpgrades(){
		// Get placements from shopMenu
		int upgradeCount = shopPlacements.transform.childCount;
		for (int i = 0; i < upgradeCount; i++) {
			// Only spawn if it hasn't been bought
			if (sS.checkFlag (i) == 0) {
				GameObject visibleUpgrade = Instantiate (shopUpgrade, shopPlacements.transform.GetChild (i));
				// Set the text
				visibleUpgrade.transform.GetChild (1).GetComponent<Text> ().text = sH.Upgrades [i].getTitle ();
				visibleUpgrade.transform.GetChild (2).GetComponent<Text> ().text = sH.Upgrades [i].getDescription ();
				visibleUpgrade.transform.GetChild (3).GetComponent<Text> ().text = "$" + sH.Upgrades [i].getPrice ().ToString ();
				// Set the icon
				visibleUpgrade.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = sH.upgradeSprites [i];
				// Set the collider information on the upgrade
				visibleUpgrade.GetComponent<shopUpgrade> ().myData = sH.Upgrades [i];
				// Set the sprites
				visibleUpgrade.transform.parent = shop.transform;
			}
		}
	}

	void loadUpgradesFromJSON (){

	}


	// Apply the upgrades from the shopStorage
	public void applyUpgrades(){
		checkCasino ();
		checkTrophy ();
	}

	void checkCasino(){
		// Instantiate the casino button if it was created
		int casinoShopUpgradeIndex = 4; // Hardcode
		if(sS.checkFlag(casinoShopUpgradeIndex) == 1){
			Instantiate (casinoButton, new Vector2 (5.5f, 2.5f), Quaternion.identity);
		}
	}

	void checkTrophy(){
		int tropyShopUpgradeIndex = 5;
		if(sS.checkFlag(tropyShopUpgradeIndex) == 1){
			Instantiate (trophyButton, new Vector2 (5.5f, 1f), Quaternion.identity);
		}
	}
}
