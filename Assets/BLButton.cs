﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BLButton : ClickButton {

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	// Update is called once per frame
	void Update () {

	}

	override public void buttonEffects() {
		// TODO dunno casino
		SceneManager.LoadScene ("casino");
	}
}