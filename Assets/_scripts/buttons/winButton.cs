using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winButton : ClickButton {

	inventoryStorage iS;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		iS.setFlag ("win");
		iS.setBalance(0);
		SceneManager.LoadScene ("End");
	}
}
