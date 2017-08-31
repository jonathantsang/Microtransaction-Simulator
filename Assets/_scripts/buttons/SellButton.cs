using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : ClickButton {

	public int cardIndex; // way to set which card is for the sell button
	private inventoryStorage iS;
	private Text countText;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		countText = transform.parent.parent.GetChild (1).GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		// Sell one of the card type of it
		iS.decreaseCardAmount (cardIndex);
		iS.increaseBalance (cardIndex); // TODO adds a default amount based on rarity
		countText.text = iS.storeCards [cardIndex].ToString (); // Hardcode change text of sibling above
	}
}
