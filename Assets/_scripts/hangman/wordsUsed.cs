using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordsUsed : MonoBehaviour {

	Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text> ();
		textComponent.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
