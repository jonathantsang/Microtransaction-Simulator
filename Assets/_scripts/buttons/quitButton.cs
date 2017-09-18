using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : ClickButton {


	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	// Update is called once per frame
	void Update () {

	}

	override public void buttonEffects(){
		// Erase all (similar to lucid) in inventoryStorage
		Application.Quit();
	}
}
