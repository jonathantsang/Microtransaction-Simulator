using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : ClickButton {

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
		// Erase all (similar to lucid) in inventoryStorage
		iS.resetProgress();
		iS.fullReset ();
	}
}
