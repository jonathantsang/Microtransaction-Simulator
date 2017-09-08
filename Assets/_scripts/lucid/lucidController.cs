using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucidController : MonoBehaviour {
	
	private popupController pC;

	// Use this for initialization
	void Start () {
		pC = GameObject.FindGameObjectWithTag ("popupController").GetComponent<popupController> ();
		lucidAnnouncement ();
		lucidTime ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void lucidAnnouncement(){
		// Create this popup first to get it behind the other one
		pC.createPopup ("Lucid means you restart all upgrades, cards, and cash for cheaper things and goodies", 4, 4, false);
		pC.createPopup ("You can lucid", 4, 4, false);
	}

	public void lucidTime(){
		pC.createPopup ("Are you sure you want to lucid?", 1, 1, true);
	}
}
