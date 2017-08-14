using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : ClickButton {

	public GameObject card;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		print ("open");
		// Create the cards here
		Transform spawnPoints = transform.GetChild(0);
		int amountofSpawnPoints = spawnPoints.childCount;
		for (int i = 0; i < amountofSpawnPoints; i++) {
			GameObject newCard = Instantiate (card, spawnPoints.transform.GetChild (i).position, Quaternion.identity);
			GameObject parent = GameObject.FindGameObjectWithTag ("cards");
			newCard.transform.parent = parent.transform;
		}
	}
}
