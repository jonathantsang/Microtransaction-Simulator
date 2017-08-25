using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour {

	public GameObject shopUpgrade;

	public GameObject shopPlacements;
	private GameObject shop;

	private shopStorage sS;

	// Use this for initialization
	void Start () {
		// shopPlacements = GameObject.FindGameObjectWithTag ("shopMenu").transform.GetChild (2).gameObject;
		sS = GameObject.FindGameObjectWithTag("shopStorage").GetComponent<shopStorage>();
		shop = GameObject.FindGameObjectWithTag ("shop");
		showUpgrades ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showUpgrades(){
		// Get placements from shopMenu
		int upgradeCount = shopPlacements.transform.childCount;
		for (int i = 0; i < upgradeCount; i++) {
			GameObject visibleUpgrade = Instantiate (shopUpgrade, shopPlacements.transform.GetChild (i));
			visibleUpgrade.transform.GetChild (1).GetComponent<Text> ().text = sS.Upgrades [i].getTitle();
			visibleUpgrade.transform.GetChild (2).GetComponent<Text> ().text = sS.Upgrades [i].getDescription ();
			visibleUpgrade.transform.GetChild (3).GetComponent<Text> ().text = "$" + sS.Upgrades [i].getPrice ().ToString ();
			visibleUpgrade.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = sS.upgradeSprites [i];
			// Set the sprites
			visibleUpgrade.transform.parent = shop.transform;
		}
	}
}
