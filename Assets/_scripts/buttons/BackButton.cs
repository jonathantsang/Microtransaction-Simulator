﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : ClickButton {

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	// Update is called once per frame
	void Update () {

	}

	override public void buttonEffects(){
		// Force save
		DataService dS = GameObject.FindGameObjectWithTag ("DataService").GetComponent<DataService> ();
		dS.forceSave();

		SceneManager.LoadScene ("OpenCrate");
	}
}
