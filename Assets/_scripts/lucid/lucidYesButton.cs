using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		// clear shopFlags, cardInfoStorage, and cardOpenStorage
		iS.lucidInventory();

		// Set lucid to 1 more
		iS.setFlag("lucid");

		// Destroy the popup
		GameObject popup = this.transform.parent.transform.parent.transform.parent.gameObject;
		Destroy(popup);
		// Try out reloading scene
		print("reload");

		SceneManager.LoadScene("OpenCrate");
	}
}
