using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucidController : MonoBehaviour {
	
	private popupController pC;
	private inventoryStorage iS;
	bool appeared;

	// Use this for initialization
	void Start () {
		pC = GameObject.FindGameObjectWithTag ("popupController").GetComponent<popupController> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		appeared = false;
		// lucidAnnouncement ();
		// lucidTime ();
	}
	
	// Update is called once per frame
	void Update () {
		// Lucid Condition
		if(iS.getBalance() > 8000 && !appeared){
			appeared = true;
			lucidPopups ();
		}
	}

	public void lucidAnnouncement(){
		// Create this popup first to get it behind the other one
		pC.createPopup ("Lucid means you restart all upgrades, cards, and cash for cheaper things and goodies", 4f, -2.5f, false);
		pC.createPopup ("You can lucid", 4f, -2.5f, false);
	}

	public void lucidTime(){
		pC.createPopup ("Are you sure you want to lucid?", 4f, -2.5f, true);
	}

	void lucidPopups(){
		lucidTime ();
		lucidAnnouncement ();
	}
}
