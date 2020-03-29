using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAllButton : ClickButton {

	private GameObject cardHolder;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		cardHolder = GameObject.FindGameObjectWithTag ("cards");
	}

	// Update is called once per frame
	void Update () {

	}

	override public void buttonEffects() {
		// Open all cards (get the card holder and open 4 of them)
		if (cardHolder != null){
			for (int i = 0; i < cardHolder.transform.childCount; i++) {
				if (cardHolder.transform.GetChild (i).GetComponent<Card> ().flipped == true) {
					continue;
				}
				cardHolder.transform.GetChild (i).GetComponent<Card> ().flipCard ();
			}
		}
	}
}
