using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : ClickButton {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		print (SceneManager.GetActiveScene ().name);
		if (SceneManager.GetActiveScene ().name == "Inventory") {
			SceneManager.LoadScene ("OpenCrate");
		} else if (SceneManager.GetActiveScene ().name == "OpenCrate") {
			SceneManager.LoadScene ("Inventory");
		}
	}
}
