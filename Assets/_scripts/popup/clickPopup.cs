using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPopup : ClickButton {

	private popupController pC;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		pC = GameObject.FindGameObjectWithTag ("popupController").GetComponent<popupController> ();
	}

	// Update is called once per frame
	void Update () {

	}

	override public void buttonEffects(){
		// Destroy the popup
		GameObject popup = this.transform.parent.gameObject;
		Destroy(popup);
	}
}
