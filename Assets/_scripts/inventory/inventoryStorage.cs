using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryStorage : MonoBehaviour {

	// Stores most of the game's data and variables
	public float Balance; // Stores the amount
	public float priceofPack;
	public List<cardInfo> cardInfoList;
	public Dictionary<int, int> storeCards; // Keep track of cards in list and dictionary using key as cardIndex and amount as value
	private Dictionary<string, int> otherFlags;

	// Other information used for achievements
	private int packsOpened = 0;
	private bool clickedAvocado = false;

	public static inventoryStorage instance;

	// Use this for initialization
	void Start () {
		priceofPack = 3.99f;

		otherFlags = new Dictionary<string, int>();
		// TODO hardcoded strings
		otherFlags["avocado"] = 0;
		otherFlags ["packsOpened"] = 0;
		otherFlags ["logo"] = 0;


		storeCards = new Dictionary<int, int>();
		for (int i = 0; i < 8; i++) { // TODO Hardcoded amount
			storeCards [i] = 0;
		}

		cardInfoList = new List<cardInfo>();
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addCard(cardInfo card){
		cardInfoList.Add (card);
		storeCards [card.getCardIndex ()] += 1;
	}

	public void purchaseCards(){
		Balance -= priceofPack;
		otherFlags ["packsOpened"] += 1;
	}

	public void decreaseCardAmount(int index){
		if (storeCards [index] > 0) {
			storeCards [index]--;
		}
	}

	public void increaseBalance(int index){
		Balance += index * 1;
	}

	public int getPacksOpened(){
		return otherFlags ["packsOpened"];
	}

	public void clickAvocado(){
		otherFlags ["avocado"] = 1;
	}

	public int getAvocadoClicked(){
		return otherFlags ["avocado"];
	}

	public int checkCard(int cardIndex){
		return otherFlags ["packsOpened"];
	}

	public int checkFlag(string key){
		return otherFlags[key];
	}

	public void setFlag(string key){
		otherFlags [key] = 1;
	}
}
