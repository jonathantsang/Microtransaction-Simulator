using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitShopButton : ClickButton {

	private GameObject shop;
	private GameObject shopMenu;
	public GameObject counter;

	// Used to check whether to create casino button
	public GameObject casinoButton;
	private shopController sC;

	// Use this for initialization
	void Start () {
		// Disable text of shop
		shop = GameObject.FindGameObjectWithTag ("shop").gameObject;
		// Disable background and quit of shop
		shopMenu = GameObject.FindGameObjectWithTag ("shopMenu").gameObject;
		// counter = GameObject.FindGameObjectWithTag ("counter").gameObject;
		sC = GameObject.FindGameObjectWithTag ("shopController").GetComponent<shopController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		// Show the menu
		shop.SetActive(false);
		shopMenu.SetActive (false);
		// Also close totalPointsCounter
		counter.SetActive(true);

		// Update the upgrades
		sC.applyUpgrades();

	}
}
