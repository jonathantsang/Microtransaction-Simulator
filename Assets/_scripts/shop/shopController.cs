using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour {

	public GameObject shopUpgrade;

	private GameObject shopPlacements;
	private GameObject shop;

	// Use this for initialization
	void Start () {
		shopPlacements = GameObject.FindGameObjectWithTag ("shopMenu").transform.GetChild (2).gameObject;
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
			visibleUpgrade.transform.GetChild (1).GetComponent<Text> ().text = "This message should wrap around and make it work.";
			visibleUpgrade.transform.parent = shop.transform;
		}
	}
}
