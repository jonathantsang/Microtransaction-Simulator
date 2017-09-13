using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class atticButton : ClickButton {

	// Use this for initialization
	protected override void Start () {
		base.Start();

	}

	// Update is called once per frame
	void Update () {

	}

	override public void buttonEffects(){
		SceneManager.LoadScene ("BlankCanvas");
	}
}
