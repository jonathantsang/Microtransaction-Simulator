using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucidNoButton : ClickButton {

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
		// Destroy the popup
		GameObject popup = this.transform.parent.transform.parent.transform.parent.gameObject;
		Destroy(popup);
	}
}
