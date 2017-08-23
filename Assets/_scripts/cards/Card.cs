using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	// Numerical value and total card value in points
	private int value;
	public int totalValue;
	private string[] rarities = {"white", "brown", "blue", "purple", "red", "green", "turquoise", "fuzz"};
	private int[] colourValues = { 100, 200, 500, 1000, 2000, 4000, 8000, 10000 };
	private string rarity;

	private bool left = true;
	public bool flipped = false;

	private SpriteRenderer frontSprite;
	private SpriteRenderer backSprite;
	private SpriteRenderer tensDigit;
	private SpriteRenderer onesDigit;
	private cardInformationStorage cDS;
	private totalPointsCounter tPS;
	private inventoryStorage iS;

	// Effect
	public ParticleSystem ps;

	// Use this for initialization
	void Start () {
		initializeCard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// Reveal the card
		if (!flipped) {
			flipCard ();
			flipped = true;
			// Notify the totalPointsCounter when cards are opened, and if they are opened, total up the score
			tPS.notify("count");
		}
	}

	// Get the value and shake if it is 80+
	void OnMouseOver(){
		/*
		if (left && value > 90 && !flipped) {
			transform.Translate (-0.2f, 0, 0);
			left = false;
		} else if (value > 90 && !flipped) {
			transform.Translate(0.2f,0,0);
			left = true;
		}*/
	}

	void OnMouseExit(){
		
	}

	void initializeCard(){

		// Find the cardInformationStorage and totalPointsCounter
		cDS = GameObject.FindGameObjectWithTag ("cardInformationStorage").GetComponent<cardInformationStorage> ();
		tPS = GameObject.FindGameObjectWithTag ("counter").GetComponent<totalPointsCounter> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();

		// Set the back and front to the correct sprite
		frontSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		backSprite = transform.GetChild (1).GetComponent<SpriteRenderer> ();
		tensDigit = transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
		onesDigit = transform.GetChild(2).GetChild(1).GetComponent<SpriteRenderer>();

		// Get random value and rarity
		int probability = 99;
		int chooseRarity = Random.Range(0, 1000) % probability;
		// Here the different colours have different possibilities

		// White has 30% chance
		int rarityIndex = 0;
		totalValue = 0;
		if (chooseRarity < 30) {
			rarityIndex = 0;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (0, 30));
			totalValue = colourValues [rarityIndex] + value;
			// Brown has 20% chance
		} else if (chooseRarity < 50) {
			rarityIndex = 1;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (0, 50));
			totalValue = colourValues [rarityIndex] + value;
			// Blue has 15% chance
		} else if (chooseRarity < 65) {
			rarityIndex = 2;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (30, 65));
			totalValue = colourValues [rarityIndex] + value;
			// Purple has 10% chance
		} else if (chooseRarity < 75) {
			rarityIndex = 3;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (50, 75));
			totalValue = colourValues [rarityIndex] + value;
			// Red has 8% chance
		} else if (chooseRarity < 83) {
			rarityIndex = 4;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (65, 83));
			totalValue = colourValues [rarityIndex] + value;
			// Green has 7% chance
		} else if (chooseRarity < 90) {
			rarityIndex = 5;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (75, 90));
			totalValue = colourValues [rarityIndex] + value;
			// Turqoise has 5% chance
		} else if (chooseRarity < 97) {
			rarityIndex = 6;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (83, 97));
			totalValue = colourValues [rarityIndex] + value;
		// Fuzz has 3% chance
		} else if (chooseRarity < 100) {
			rarityIndex = 7;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (90, 99));
			totalValue = colourValues [rarityIndex] + value;
		}

		// Initialize the back and front
		frontSprite.sprite = cDS.colours [rarityIndex];
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
		// Opening effect
		if (value > 80) {
			Instantiate (ps, transform);
		}
		// Store the card information in the inventory Storage
		cardInfo newCard= new cardInfo(value, totalValue, rarity);
		iS.addCard(newCard);
	}
}
