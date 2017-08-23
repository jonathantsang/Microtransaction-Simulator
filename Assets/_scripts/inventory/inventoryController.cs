using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour {

	GameObject inventory;
	inventoryStorage iS;

	private string[] rarities = {"white", "brown", "blue", "purple", "red", "green", "turquoise", "fuzz"};

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("inventory");
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
			int leng = iS.cardInfoList.Count;
			// For each card in the cardInfo List
			for (int i = 0; i < leng; i++) {
				int childIndex = 0;
				// Find the index of the child counter
				for (int j = 0; j < rarities.Length; j++) {
					if (iS.cardInfoList [i].getRarity () == rarities [j]) {
						childIndex = j;
						break;
					}
				}
				Text childText = inventory.transform.GetChild (childIndex).transform.GetChild (1).GetComponent<Text> ();
				int amount = System.Int16.Parse (childText.text);
				amount++;
				// Set the dictionary to the correct amount of the card
				iS.storeCards [childIndex] = amount;
				childText.text = amount.ToString ();
			}
		}
	}
}
