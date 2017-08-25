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

	private shopHolder sS;

	// Use this for initialization
	void Start () {
		// shopPlacements = GameObject.FindGameObjectWithTag ("shopMenu").transform.GetChild (2).gameObject;
		sS = GameObject.FindGameObjectWithTag("shopHolder").GetComponent<shopHolder>();
		shop = GameObject.FindGameObjectWithTag ("shop").gameObject;
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
			GameObject visibleUpgrade = Instantiate (shopUpgrade, shopPlacements.transform.GetChild (i));
			// Set the text
			visibleUpgrade.transform.GetChild (1).GetComponent<Text> ().text = sS.Upgrades [i].getTitle();
			visibleUpgrade.transform.GetChild (2).GetComponent<Text> ().text = sS.Upgrades [i].getDescription ();
			visibleUpgrade.transform.GetChild (3).GetComponent<Text> ().text = "$" + sS.Upgrades [i].getPrice ().ToString ();
			// Set the icon
			visibleUpgrade.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = sS.upgradeSprites [i];
			// Set the collider information on the upgrade
			visibleUpgrade.GetComponent<shopUpgrade>().myData = sS.Upgrades[i];
			// Set the sprites
			visibleUpgrade.transform.parent = shop.transform;
		}
	}

	// Apply the upgrades from the shopStorage
	void applyUpgrades(){
		
	}
}
