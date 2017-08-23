using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryStorage : MonoBehaviour {

	private string[] rarities = {"white", "brown", "blue", "purple", "red", "green", "turquoise", "fuzz"};

	// Stores most of the game's data and variables
	public float Balance; // Stores the amount
	public float priceofPack;
	public List<cardInfo> cardInfoList;
	public Dictionary<int, int> storeCards; // Keep track of cards in list and dictionary

	public static inventoryStorage instance;

	// Use this for initialization
	void Start () {
		priceofPack = 3.99f;

		storeCards = new Dictionary<int, int>();
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
		print ("added card");
	}

	public void purchaseCards(){
		Balance -= priceofPack;
	}

	public void sellCard(int index){
		for (int i = 0; i < cardInfoList.Count; i++) {
			if (cardInfoList [i].getRarity () == rarities [index]) {
				cardInfoList.Remove (cardInfoList [i]);
			}
		}
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
