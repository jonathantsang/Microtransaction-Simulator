using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : ClickButton {

	public GameObject card;
	private List<GameObject> cardList;
	private totalPointsCounter tPS;

	// Use this for initialization
	void Start () {
		cardList = new List<GameObject> ();
		tPS = GameObject.FindGameObjectWithTag ("counter").GetComponent<totalPointsCounter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		// Clear the old cards, if they exist

		int leng = cardList.Count;
		for (int i = 0; i < leng; i++) {
			print ("deleted");
			Destroy (cardList [i]);
		}
		cardList.Clear ();
		tPS.notify("clear");

		print ("open");
		// Create the cards here
		Transform spawnPoints = transform.GetChild(0);
		int amountofSpawnPoints = spawnPoints.childCount;
		for (int i = 0; i < amountofSpawnPoints; i++) {
			print ("make card");
			GameObject newCard = Instantiate (card, spawnPoints.transform.GetChild (i).position, Quaternion.identity);
			cardList.Add (newCard);
			GameObject parent = GameObject.FindGameObjectWithTag ("cards");
			newCard.transform.parent = parent.transform;
		}

		print (cardList.Count);

		print ("setup");
		// Notify the totalPointsCounter to initialize the tracking of the flipped cards
		tPS.setup();

	}
}
