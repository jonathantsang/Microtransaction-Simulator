using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopButton : ClickButton {

	GameObject shop;
	public GameObject shopMenu;
	GameObject counter;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		// Disable text of shop
		shop = GameObject.FindGameObjectWithTag ("shop").gameObject;
		shop.SetActive (false);
		// Disable background and quit of shop
		// shopMenu = GameObject.FindGameObjectWithTag ("shopMenu").gameObject;
		shopMenu.SetActive (false);
		counter = GameObject.FindGameObjectWithTag ("counter").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		// Show the menu
		shop.SetActive(true);
		shopMenu.SetActive (true);
		// Also close totalPointsCounter
		counter.SetActive(false);
	}
}
