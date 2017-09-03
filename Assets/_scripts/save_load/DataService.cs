using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataService : MonoBehaviour {

	float timer = 0;
	float timeLength = 0.3f;

	private inventoryStorage iS;
	private shopStorage sS;

	public SaveData SaveData { get; private set; }

	// Use this for initialization
	void Start () {
		iS = GameObject.FindGameObjectWithTag("inventoryStorage").GetComponent<inventoryStorage>();
		sS = GameObject.FindGameObjectWithTag("shopStorage").GetComponent<shopStorage>();

		SaveData = new SaveData ();
		SaveData.cards = new cardInfoArray();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > timeLength) {
			print ("saved");
			// Hide with functions

			SaveData.cards.cardsList = iS.cardInfoList;
			SaveData.cards.cardDict = iS.storeCards;

			SaveData.WriteToFile ("catch.gd");
			timer = 0;
		}
		timer += Time.deltaTime;
	}

}
