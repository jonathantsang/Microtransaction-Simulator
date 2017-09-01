using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour {

	private GameObject inventory;
	private inventoryStorage iS;
	private inventorySpriteHolder iSH;
	private GameObject placements;

	public GameObject inventoryCard;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("inventory");
		placements = inventory.transform.GetChild (0).gameObject; // Hard code fine placements
		iSH = GameObject.FindGameObjectWithTag ("inventorySpriteHolder").GetComponent<inventorySpriteHolder>();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage>();
		// Since the inventoryController is only in this, it can run only when start is run. (Not when scene is loaded,
		// since it is not persistent like inventoryStorage
		setupInventory();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setupInventory(){
		if (inventory) {

			// Set up card prefabs for each card
			int placementLeng = placements.transform.childCount;
			for (int i = 0; i < placementLeng; i++) {
				GameObject newCard = Instantiate (inventoryCard, placements.transform.GetChild (i).transform);
				newCard.transform.parent = inventory.transform;
				// Change card to correct one
				newCard.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = iSH.sprites[i];
				// Set cardIndex to correct rarity
				newCard.transform.GetChild(2).GetChild(1).GetComponent<SellButton>().cardIndex = i; // Hard code
			}
	
			// For each card in the dictionary
			int cardDictionaryLength = 8; // TODO fix hardcode
			// i+1 for child because placement is the first child
			for (int i = 0; i < cardDictionaryLength; i++) {
				Text childText = inventory.transform.GetChild (i+1).transform.GetChild (1).GetComponent<Text> ();
				int amount = iS.storeCards [i];
				childText.text = amount.ToString ();
			}
		}
	}
}
