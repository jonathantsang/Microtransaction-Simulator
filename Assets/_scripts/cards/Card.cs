using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	int value;
	string[] rarities = {"white", "brown", "blue", "purple", "red", "green", "turquoise", "fuzz"};
	string rarity;

	private SpriteRenderer frontSprite;
	private SpriteRenderer backSprite;
	private SpriteRenderer tensDigit;
	private SpriteRenderer onesDigit;
	private cardInformationStorage cDS;

	bool left = true;

	// Use this for initialization
	void Start () {
		initializeCard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// Reveal the card
		flipCard();
	}

	// Get the value and shake if it is 80+
	void OnMouseOver(){
		print (Time.time);
		if (left) {
			transform.Translate (-0.1f, 0, 0);
			left = false;
		} else {
			transform.Translate(0.1f,0,0);
			left = true;
		}
	}

	void OnMouseExit(){
		
	}

	void initializeCard(){
		// Find the cardInformationStorage
		cDS = GameObject.FindGameObjectWithTag ("cardInformationStorage").GetComponent<cardInformationStorage> ();

		// Set the back and front to the correct sprite
		frontSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		backSprite = transform.GetChild (1).GetComponent<SpriteRenderer> ();
		tensDigit = transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
		onesDigit = transform.GetChild(2).GetChild(1).GetComponent<SpriteRenderer>();

		// Get random value and rarity
		int chooseRarity = Random.Range(0, 1000) % rarities.Length;
		rarity = rarities[chooseRarity];
		value = (int)Mathf.Ceil (Random.Range (50, 99));

		// For some reason it can only find it for one card

		// Initialize the back and front
		frontSprite.sprite = cDS.colours [chooseRarity];
		backSprite.sprite = cDS.back;
		tensDigit.sprite = cDS.numbers[value / 10];
		onesDigit.sprite = cDS.numbers[value % 10];

	}

	void flipCard(){
		// make a separate function that swaps the sprites and the numbers as well
		frontSprite.sortingLayerName = "foreground";
		backSprite.sortingLayerName = "background";
		tensDigit.sortingLayerName = "foreground";
		onesDigit.sortingLayerName = "foreground";
	}
}
