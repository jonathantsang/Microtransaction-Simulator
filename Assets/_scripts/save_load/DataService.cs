using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataService : MonoBehaviour {

	public static DataService instance;

	float timer = 0;
	float timeLength = 0.3f;

	private inventoryStorage iS;
	private shopStorage sS;

	public SaveData SaveData { get; private set; }

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		iS = GameObject.FindGameObjectWithTag("inventoryStorage").GetComponent<inventoryStorage>();
		sS = GameObject.FindGameObjectWithTag("shopStorage").GetComponent<shopStorage>();

		// At the start try to read from the file
		SaveData = SaveData.ReadFromFile ("catch.gd");
		if (SaveData != null) {
			Debug.Log ("preloaded");
			// This will fail if the object exists, but doesn't have the correct components
			if(SaveData.cardsInfoList.cardsTotal == null){
				Debug.Log ("corruption");

				SaveData = new SaveData ();
				SaveData.cardsInfoList = new cardInfoList ();
			}
			iS.cardInfoList = SaveData.cardsInfoList.cardsTotal;

			// This makes a new dictionary based on the catch.gd file
			Dictionary<int, int> newDict = new Dictionary<int, int> ();
			// Make a new dictionary with 8 possible colours
			int numColours = 8;
			for (int i = 0; i < numColours; i++) {
				newDict [i] = 0;
			}
			// For now, since serialization doesn't work with dict, TODO hardcode new dictionary 
			for (int i = 0; i < SaveData.cardsInfoList.cardsTotal.Count; i++) {
				// Create new dictionary using the cardInfoList
				newDict [iS.cardInfoList [i].getCardIndex()] += 1;
			}
			iS.storeCards = newDict;
			// Balance should be default 0
			iS.setBalance (SaveData.Balance);
		} else {
			Debug.Log ("no preload");

			SaveData = new SaveData ();
			SaveData.cardsInfoList = new cardInfoList ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (timer > timeLength) {
			// Hide with functions

			// TODO hardcoded saves
			SaveData.cardsInfoList.cardsTotal = iS.cardInfoList;
			SaveData.Balance = iS.getBalance ();
			SaveData.priceOfPack = iS.priceOfPack;
			SaveData.cardsOpenList.cardsOpened = iS.cardOpenList;
			// TODO fix later with the dictionary fix hardcoded
			// SaveData.cards.cardDict = iS.storeCards;

			SaveData.WriteToFile ("catch.gd");
			timer = 0;
		}
		timer += Time.deltaTime;
	}

}
