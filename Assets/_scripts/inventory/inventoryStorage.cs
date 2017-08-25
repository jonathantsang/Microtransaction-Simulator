using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryStorage : MonoBehaviour {

	// Stores most of the game's data and variables
	public float Balance; // Stores the amount
	public float priceofPack;
	public List<cardInfo> cardInfoList;
	public Dictionary<int, int> storeCards; // Keep track of cards in list and dictionary using key as cardIndex and amount as value

	public static inventoryStorage instance;

	// Use this for initialization
	void Start () {
		priceofPack = 3.99f;

		storeCards = new Dictionary<int, int>();
		for (int i = 0; i < 8; i++) {
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
	}

	public void decreaseCardAmount(int index){
		if (storeCards [index] > 0) {
			storeCards [index]--;
		}
	}

	public void increaseBalance(int index){
		Balance += index * 1;
	}

}
