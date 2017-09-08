using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucidYesButton : ClickButton {

	inventoryStorage iS;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		print ("yes");
		// Set lucid to 1 more
		iS.setFlag("lucid");

		// clear shopFlags, cardInfoStorage, and cardOpenStorage
		iS.lucidInventory();

		// Destroy the popup
		GameObject popup = this.transform.parent.transform.parent.transform.parent.gameObject;
		Destroy(popup);
	}
}
