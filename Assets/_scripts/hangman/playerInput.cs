using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour {

	GameObject keyItems;
	int hangmanControllerIndex = 0;
	hangmanController hC;

	// Use this for initialization
	void Start () {
		keyItems = GameObject.FindGameObjectWithTag ("keyItems").gameObject;
		hC = keyItems.transform.GetChild (hangmanControllerIndex).GetComponent<hangmanController> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			if (!hC.won && hC.tries > 0) {
				hC.Input (c);
				hC.tries--;
			}
		}
	}
		
}
