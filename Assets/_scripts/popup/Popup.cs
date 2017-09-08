using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

	private Text textPortion;
	int textPortionIndex = 1;
	int choicesIndex = 3;

	public bool choices = false;
	private GameObject choicesObject;

	// Use this for initialization
	void Start () {
		choicesObject = transform.GetChild (choicesIndex).gameObject;
		// TODO fix hardcoded index for textPortion
		if(!choices){
			choicesObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setText(string text){
		textPortion = transform.GetChild (textPortionIndex).GetComponent<Text> ();
		textPortion.text = text;
	}
}
