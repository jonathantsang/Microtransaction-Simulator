using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataService : MonoBehaviour {

	public static DataService instance;

	float timer = 0;
	float timeLength = 0.8f;

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

		try{
			// At the start try to read from the file
			SaveData = SaveData.ReadFromFile ("catch.gd");
		} catch (System.Exception e){
			Debug.Log ("corruption");
			createNewFile ();
			iS.setFlag ("corruption");
			writeToFile ();
		}
		if (SaveData != null) {
			// This will fail if the object exists, but doesn't have the correct components
			if (SaveData.cardsInfoList == null || SaveData.cardsOpenList == null ||
				SaveData.cardsStoreList == null || SaveData.shopFlagList == null) {
				Debug.Log ("corruption");
				createNewFile ();
				iS.setFlag ("corruption");
				writeToFile ();
			} else {
				Debug.Log ("preloaded");
				loadDataFromJSON ();
			}
		} else {
			Debug.Log ("no preload");
			createNewFile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > timeLength) {
			updateSaveData();
			// TODO fix later with the dictionary fix hardcoded
			// SaveData.cards.cardDict = iS.storeCards;
			writeToFile();
			timer = 0;
		}
		timer += Time.deltaTime;
	}

	// Stores data from JSON into the inventoryStorage and shopStorage (reverse of updateFile())
	void loadDataFromJSON(){
		iS.cardInfoList = SaveData.cardsInfoList.cardsTotal;
		iS.setBalance (SaveData.Balance);
		iS.priceOfPack = SaveData.priceOfPack;
		iS.cardOpenList = SaveData.cardsOpenList.cardsOpened;
		iS.storeCards = SaveData.cardsStoreList.storeCount;
		sS.shopUpgradeFlags = SaveData.shopFlagList.setFlags;

		// Other flags needs to be converted from list to dictionary
		string[] flags = new string[] {"avocado", "packsOpened", "hangman", "logo", "lucid", "win", "corruption", "hangman", "soundOn"}; 
		// This may corrupt since we need more size, check for smaller
		if(flags.Length > SaveData.otherFlagList.setOtherFlags.Count){
			print ("hard repair");
			int flagAmount = 12; // TODO fix hardcode. Currently more other flags
			for (int i = 0; i < flagAmount; i++) {
				SaveData.otherFlagList.setOtherFlags.Add (0);
			}	
		}
		// If any of them are null, create them to save from json
		if (iS.otherFlags == null || iS.cardOpenList == null || iS.cardOpenList == null) {
			iS.createData ();
		}
		// Set the otherflags
		for (int i = 0; i < flags.Length; i++) {
			iS.otherFlags [flags [i]] = SaveData.otherFlagList.setOtherFlags [i];
		}
	}

	// Updates the SaveData to have the inventoryStorage info and shopStorage info
	void updateSaveData(){
		// TODO hardcoded saves
		if (SaveData != null) {
			SaveData.cardsInfoList.cardsTotal = iS.cardInfoList;
			SaveData.Balance = iS.getBalance ();
			SaveData.priceOfPack = iS.priceOfPack;
			SaveData.cardsOpenList.cardsOpened = iS.cardOpenList;
			SaveData.cardsStoreList.storeCount = iS.storeCards;

			// TODO fix hardcode dictionary
			SaveData.shopFlagList.setFlags = sS.shopUpgradeFlags;

			string[] flags = new string[] {"avocado", "packsOpened", "hangman", "logo", "lucid", "win", "corruption", "hangman", "soundOn"};
			for (int i = 0; i < flags.Length; i++) {
				if (SaveData == null) {
					createNewFile ();
				}
				// This gets the value on or off from otherFlags the Dictionary and saves it to the SaveData otherFlagList int array
				SaveData.otherFlagList.setOtherFlags [i] = iS.otherFlags [flags [i]];
			}
		}
	}

	// Writes to catch.gd
	void writeToFile(){
		if (SaveData == null) {
			createNewFile ();
		}
		SaveData.WriteToFile ("catch.gd");
	}

	public void forceSave(){
		print ("force saved");
		updateSaveData ();
		writeToFile ();
	}

	void createNewFile(){
		SaveData = new SaveData ();
		SaveData.cardsInfoList = new cardInfoList ();
		SaveData.cardsOpenList = new cardOpenList ();
		SaveData.shopFlagList = new shopFlagList ();
		SaveData.cardsStoreList = new cardStoreList ();
		SaveData.otherFlagList = new otherFlagList ();
	}


	/* // Creates dict from existing 
	void createDict(){
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
			newDict [iS.cardInfoList [i].getCardIndex ()] += 1;
		}
		iS.storeCards = newDict; // This is technically updating the dict, which can be in loadDataFromJSON()
	}*/

}

