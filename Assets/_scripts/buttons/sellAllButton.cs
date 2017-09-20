using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sellAllButton : ClickButton {

	inventoryStorage iS;
	GameObject inventory;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		inventory = GameObject.FindGameObjectWithTag ("inventory").gameObject;

	}

	override public void buttonEffects(){
		iS.sellAll ();
		clearTextInventory ();
	}

	void clearTextInventory(){
		// For each card in the dictionary
		int cardDictionaryLength = 8; // TODO fix hardcode
		// i+1 for child because placement is the first child
		for (int i = 0; i < cardDictionaryLength; i++) {
			Text childText = inventory.transform.GetChild (i+1).transform.GetChild (1).GetComponent<Text> ();
			int amount = 0;
			childText.text = amount.ToString ();
		}
	}
}
