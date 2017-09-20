using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryStorage : MonoBehaviour {

	// Stores most of the game's data and variables
	private float Balance; // Stores the amount
	public float priceOfPack = 3.99f;
	private float limitingFactor = 0.3f;

	public List<cardInfo> cardInfoList;	// This is a list of each card opened
	public List<cardOpen> cardOpenList; // This is a list of cardOpen, which store 4 cards opened at one time

	// Also do cardComboes later

	// Uses a list to serialize
	public List<int> storeCards; // Keep track of cards in list and dictionary using key as cardIndex and amount as value
	public Dictionary<string, int> otherFlags;

	// Other information used for achievements
	public static inventoryStorage instance;

	private shopStorage sS;

	private bool early;

	DataService dS;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		createData ();
		// remove on September 19th
		early = false;

		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage> ();
		dS = GameObject.FindGameObjectWithTag ("DataService").GetComponent<DataService> ();


		priceOfPack = 3.99f;
		limitingFactor = 0.3f;

	}
	
	// Update is called once per frame
	void Update () {
	}

	// Link constantly if it cannot do it initially
	void conditionalLink(){
		
	}

	// Cyclic starting so this is called from DataService
	public void createData(){
		// Used to keep track which cards were opened together
		otherFlags = new Dictionary<string, int>();
		cardInfoList = new List<cardInfo>();
		cardOpenList = new List<cardOpen> ();
		prepOtherFlags ();
		prepStoreCards ();
	}

	void prepStoreCards(){
		storeCards = new List<int> ();
		for (int i = 0; i < 8; i++) { // TODO Hardcoded amount
			storeCards.Add(0);
		}
	}

	void prepOtherFlags(){
		// TODO fix hardcoded strings
		otherFlags["avocado"] = 0;
		otherFlags ["packsOpened"] = 0;
		otherFlags ["hangman"] = 0;
		otherFlags ["logo"] = 0;

		// Number of times prestiged, don't reset this in lucid
		otherFlags["lucid"] = 0;
		otherFlags ["win"] = 0;
		otherFlags ["corruption"] = 0;
		otherFlags ["hangman"] = 0;
		otherFlags ["soundOn"] = 1;
	}

	public void addCard(cardInfo card){
		cardInfoList.Add (card);
		storeCards [card.getCardIndex()] += 1;
	}

	public void purchaseCards(){
		Balance -= priceOfPack;
		otherFlags ["packsOpened"] += 1;
	}

	public void decreaseCardAmount(int index){
		if (storeCards [index] > 0) {
			storeCards [index]--;
		}
	}

	public void increaseBalance(int index){
		// TODO fix rarity
		float added = Mathf.Pow(2, index);
		Balance += added;
	}

	public int getPacksOpened(){
		if (otherFlags != null) {
			return otherFlags ["packsOpened"];
		}
		return 0;
	}

	// Handles lucid perks
	public void lucidInventory(){
		print ("lucid");
		// TODO fix pricedrop that is hardcoded right now
		if (priceOfPack - 0.75 < 0) {
			priceOfPack = 0.5f;
		} else {
			priceOfPack -= 0.75f;
		}
		clearOtherFlags ();
		resetProgress ();
		// This should force the lucid erasing to the savedata when it reloads 
		dS.forceSave ();
	}

	// Used to reset everything
	public void resetProgress(){
		Balance = 0;
		cardInfoList = new List<cardInfo> ();
		cardOpenList = new List<cardOpen> ();
		storeCards = new List<int> ();
		prepStoreCards (); // This makes it size 8
		otherFlags = new Dictionary<string, int> ();

		sS.clearShopFlags ();
		prepOtherFlags();
		clearOtherFlags ();
		print ("cleared");
	}

	// Only used on full reset
	public void fullReset(){
		// All progress is wiped except lucid needs to be reset manually and price of pack is reset
		otherFlags ["lucid"] = 0;
		priceOfPack = 3.99f;
	}

	// clears OtherFlags flags to be reset
	void clearOtherFlags(){
		otherFlags["avocado"] = 0;
		otherFlags ["packsOpened"] = 0;
		otherFlags ["hangman"] = 0;
		otherFlags ["win"] = 0;
		otherFlags ["corruption"] = 0;
		otherFlags ["hangman"] = 0;
		otherFlags ["soundOn"] = 1;
	}

	// Setter and Getters mainly

	public void clickAvocado(){
		otherFlags ["avocado"] += 1;
	}

	public int getAvocadoClicked(){
		return otherFlags ["avocado"];
	}

	public int checkCard(int cardRarity){
		return storeCards [cardRarity];
	}

	public int checkFlag(string key){
		if(otherFlags != null){
			return otherFlags [key];
		} else {
			return 0;
		}
	}

	public void setFlag(string key){
		if (key == "soundOn") { // soundOn is the only flag that can be flipped 0 for off, 1 for on
			otherFlags [key] = Mathf.Abs (otherFlags [key] - 1);
		} else {
			otherFlags [key] += 1;
		}
	}

	public void changeBalance(float change){
		Balance += change;
		System.Math.Round (Balance, 2);
	}

	public float getBalance(){
		return Balance;
	}

	// Used for loading from file
	public void setBalance(float newBalance){
		Balance = newBalance;
	}

	public bool canSell(int cardIndex){
		return storeCards [cardIndex] > 0;
	}

	public bool getEarly(){
		return early;
	}

	// get total value for sell all
	public void sellAll(){
		int storeCardsLength = storeCards.Count;
		float total = 0;
		for (int i = 0; i < storeCardsLength; i++) {
			// get the total worth of those cards
			float moneyCalc = storeCards[i] * Mathf.Pow (2, i);
			// Zero out counts
			storeCards [i] = 0;
			// Get the value from cardInformationHolder, and each index of StoreCards to add it up
			total += moneyCalc;
		}
		// You get 30% of what you would get if you did it manually, lucid increases it (implement later)
		Balance += total * limitingFactor;
		}
}

