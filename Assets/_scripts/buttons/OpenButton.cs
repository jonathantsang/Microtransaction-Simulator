using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : ClickButton {

	public GameObject card;
	private List<GameObject> cardList;
	private totalPointsCounter tPS;
	private inventoryStorage iS;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		cardList = new List<GameObject> ();
		tPS = GameObject.FindGameObjectWithTag ("counter").GetComponent<totalPointsCounter>();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override public void buttonEffects(){
		iS.purchaseCards ();

		// Clear the old cards, if they exist

		int leng = cardList.Count;
		for (int i = 0; i < leng; i++) {
			Destroy (cardList [i]);
		}
		cardList.Clear ();
		tPS.notify("clear");

		// Create the cards here
		Transform spawnPoints = transform.GetChild(0);
		int amountofSpawnPoints = spawnPoints.childCount;
		for (int i = 0; i < amountofSpawnPoints; i++) {
			GameObject newCard = Instantiate (card, spawnPoints.transform.GetChild (i).position, Quaternion.identity);
			cardList.Add (newCard);
			GameObject parent = GameObject.FindGameObjectWithTag ("cards");
			newCard.transform.parent = parent.transform;
		}
	}
}
