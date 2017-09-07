using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class casinoButton : ClickButton {

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects() {
		// TODO fix location, casino is now hangman
		SceneManager.LoadScene ("Hangman");
	}
}
