using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour {

	GameObject keyItems;
	int hangmanControllerIndex = 0;
	hangmanController hC;
	inventoryStorage iS;
	bool doOnce;

	// Use this for initialization
	void Start () {
		doOnce = true;
		keyItems = GameObject.FindGameObjectWithTag ("keyItems").gameObject;
		hC = keyItems.transform.GetChild (hangmanControllerIndex).GetComponent<hangmanController> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			if (!hC.won && hC.tries > 0) {
				hC.Input (c);
				if (hC.checkWon () && doOnce) {
					doOnce = false;
					// TODO make a win
					iS.setFlag("hangman");
				}
			}
		}
	}
		
}
