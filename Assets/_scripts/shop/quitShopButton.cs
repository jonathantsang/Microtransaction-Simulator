using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitShopButton : ClickButton {

	GameObject shop;
	GameObject shopMenu;
	public GameObject counter;

	// Use this for initialization
	void Start () {
		// Disable text of shop
		shop = GameObject.FindGameObjectWithTag ("shop").gameObject;
		// Disable background and quit of shop
		shopMenu = GameObject.FindGameObjectWithTag ("shopMenu").gameObject;
		// counter = GameObject.FindGameObjectWithTag ("counter").gameObject;
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
	}
}
