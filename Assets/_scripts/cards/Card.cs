using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum colour {white, brown, blue, purple, red, green, turquoise, fuzz};

public class Card : MonoBehaviour {

	// Numerical value and total card value in points
	private int value;
	public int totalValue;

	private string[] rarities = {"white", "brown", "blue", "purple", "red", "green", "turquoise", "fuzz"};
	private int[] colourValues = { 100, 200, 500, 1000, 2000, 4000, 8000, 10000 };

	private string[] raritiesLucid = {"white", "brown", "blue", "purple", "red", "green", "turquoise", "fuzz", "shine", "pyramid", "wisp", "scorch" };
	private int[] colourValuesLucid = { 10, 20, 50, 100, 200, 400, 800, 1000, 12000, 20000, 50000, 100000 };


	private string rarity;
	private int rarityIndex;

	private bool left = true;
	private cardInfo information;

	public bool flipped = false;

	private SpriteRenderer frontSprite;
	private SpriteRenderer backSprite;
	private SpriteRenderer hundredsDigit;
	private SpriteRenderer tensDigit;
	private SpriteRenderer onesDigit;
	private cardInformationHolder cIH;
	private totalPointsCounter tPS;
	private inventoryStorage iS;
	private audioStorage aS;

	// Effect
	public ParticleSystem ps;
	private GameObject Illuminate;

	// Use this for initialization
	void Start () {
		initializeCard ();
		setIlluminate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver ()
	{
		if (!flipped) {
			Illuminate.SetActive (true);
		}
	}

	void OnMouseExit ()
	{
		Illuminate.SetActive (false);

	}

	void OnMouseDown(){
		// Reveal the card
		if (!flipped) {
			flipCard ();
			flipped = true;
			// set illuminate to false on flip
			Illuminate.SetActive (false);
			// Notify the totalPointsCounter when cards are opened, and if they are opened, total up the score
			tPS.notify("count");
		}
	}

	void initializeCard(){

		// Find the cardInformationHolder and totalPointsCounter
		cIH = GameObject.FindGameObjectWithTag ("cardInformationHolder").GetComponent<cardInformationHolder> ();
		tPS = GameObject.FindGameObjectWithTag ("counter").GetComponent<totalPointsCounter> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		aS = GameObject.FindGameObjectWithTag ("audioStorage").GetComponent<audioStorage> ();

		// Set the back and front to the correct sprite
		frontSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		backSprite = transform.GetChild (1).GetComponent<SpriteRenderer> ();
		// Set up digits on the card
		hundredsDigit = transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
		tensDigit = transform.GetChild(2).GetChild(1).GetComponent<SpriteRenderer>();
		onesDigit = transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>();

		// If lucid
		if(iS.checkFlag("lucid") > 0){
			generateCardColourLucid ();
		// If no lucid
		} else {
			generateCardColour ();
		}
	}

	void flipCard(){
		// make a separate function that swaps the sprites and the numbers as well
		frontSprite.sortingLayerName = "foreground";
		backSprite.sortingLayerName = "background";
		hundredsDigit.sortingLayerName = "foreground";
		tensDigit.sortingLayerName = "foreground";
		onesDigit.sortingLayerName = "foreground";
		// Opening effect
		if (rarityIndex > 4) {
			Instantiate (ps, transform);
			// TODO fix Hardcode shine effect
			int shineEffect = 2;
			aS.playAudio (shineEffect);
		}
		// Store the card information in the inventory Storage
		iS.addCard(information);
	}

	private string getRarity(){
		return rarity;
	}

	public cardInfo getCardInfo(){
		return information;
	}

	void setIlluminate(){
		int IlluminateIndex = 3;
		int shineIndex = 0;
		// Choose from 4 shines, 0 and 1 are for regular cards 2 for good, 3 for rares
		if ((int)information.getRarity() < 3) {
			shineIndex = Random.Range (0, 1);
		} else if ((int)information.getRarity() < 4) {
			shineIndex = Random.Range (1, 2);
		} else {
			shineIndex = Random.Range (2, 3);
		}
		SpriteRenderer IlluminateSprite = transform.GetChild (IlluminateIndex).GetComponent<SpriteRenderer> ();
		IlluminateSprite.sprite = cIH.borders[shineIndex];

		// Turn on or off Illuminate
		Illuminate = transform.GetChild(IlluminateIndex).gameObject;
		Illuminate.SetActive (false);
	}

	void generateCardColour(){
		// Get random value and rarity
		int probability = 1000;
		int chooseRarity = Random.Range(0, 1000) % probability;
		// Here the different colours have different possibilities

		// cIH.getChance(<number>) gives a THREE digit number out of 999
		rarityIndex = 0;
		totalValue = 0;
		// White
		if (chooseRarity < cIH.getChance(0)) {
			rarityIndex = 0;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (0, 30));
			totalValue = colourValues [rarityIndex] + value;
			// Brown
		} else if (chooseRarity < cIH.getChance(1)) {
			rarityIndex = 1;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (0, 50));
			totalValue = colourValues [rarityIndex] + value;
			// Blue
		} else if (chooseRarity < cIH.getChance(2)) {
			rarityIndex = 2;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (30, 65));
			totalValue = colourValues [rarityIndex] + value;
			// Purple
		} else if (chooseRarity < cIH.getChance(3)) {
			rarityIndex = 3;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (50, 75));
			totalValue = colourValues [rarityIndex] + value;
			// Red
		} else if (chooseRarity < cIH.getChance(4)) {
			rarityIndex = 4;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (65, 83));
			totalValue = colourValues [rarityIndex] + value;
			// Green
		} else if (chooseRarity < cIH.getChance(5)) {
			rarityIndex = 5;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (75, 90));
			totalValue = colourValues [rarityIndex] + value;
			// Turqoise
		} else if (chooseRarity < cIH.getChance(6)) {
			rarityIndex = 6;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (83, 97));
			totalValue = colourValues [rarityIndex] + value;
			// Fuzz
		} else if (chooseRarity < cIH.getChance(7)) {
			rarityIndex = 7;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (90, 99));
			totalValue = colourValues [rarityIndex] + value;
		}

		// Initialize the back and front
		frontSprite.sprite = cIH.colours [rarityIndex];
		backSprite.sprite = cIH.back;

		tensDigit.sprite = cIH.numbers[value / 10];
		onesDigit.sprite = cIH.numbers[value % 10];

		// Initialize the card's info
		information = new cardInfo(value, totalValue, rarity, (colour)rarityIndex);
	}

	// Allows more colours
	void generateCardColourLucid(){

		// Get random value and rarity
		int probability = 10000;
		int chooseRarity = Random.Range(0, 10000) % probability;
		// Here the different colours have different possibilities

		// cIH.getChance(<number>) gives a THREE digit number out of 999
		rarityIndex = 0;
		totalValue = 0;

		// What is happening:
		// chooseRarity is a number from 0 - 9999
		// Compares with cardInfoHolder (cIH) to see which colour that rng is
		// get the rarity from the rarities index and sets the value, and total value

		print (chooseRarity);

		// White
		if (chooseRarity < cIH.getChanceLucid(0)) {
			rarityIndex = 0;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (0, 100));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Brown
		} else if (chooseRarity < cIH.getChanceLucid(1)) {
			rarityIndex = 1;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (100, 200));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Blue
		} else if (chooseRarity < cIH.getChanceLucid(2)) {
			rarityIndex = 2;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (200, 300));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Purple
		} else if (chooseRarity < cIH.getChanceLucid(3)) {
			rarityIndex = 3;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (300, 400));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Red
		} else if (chooseRarity < cIH.getChanceLucid(4)) {
			rarityIndex = 4;
			rarity = rarities [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (400, 500));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Green
		} else if (chooseRarity < cIH.getChanceLucid(5)) {
			rarityIndex = 5;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (500, 600));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Turqoise
		} else if (chooseRarity < cIH.getChanceLucid(6)) {
			rarityIndex = 6;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (600, 700));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Fuzz
		} else if (chooseRarity < cIH.getChanceLucid(7)) {
			rarityIndex = 7;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (700, 800));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Shine
		} else if (chooseRarity < cIH.getChanceLucid(8)) {
			rarityIndex = 8;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (800, 900));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Pyramid
		} else if (chooseRarity < cIH.getChanceLucid(9)) {
			rarityIndex = 9;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (900, 1000));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Wisp
		} else if (chooseRarity < cIH.getChanceLucid(10)) {
			rarityIndex = 10;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (950, 1000));
			totalValue = colourValuesLucid [rarityIndex] + value;
			// Scorch
		} else if (chooseRarity < cIH.getChanceLucid(10)) {
			rarityIndex = 11;
			rarity = raritiesLucid [rarityIndex];
			value = (int)Mathf.Ceil (Random.Range (975, 1000));
			totalValue = colourValuesLucid [rarityIndex] + value;
		}

		// Add 8 - 11 for more cards in lucid

		// Initialize the back and front
		frontSprite.sprite = cIH.colours [rarityIndex];
		backSprite.sprite = cIH.back;

		// More complicated since it is now a 3 digit potentially (can be 0-3 digits)
		print (value);
		if (value / 100 != 0) {
			hundredsDigit.sprite = cIH.numbers [value / 100];
		}
		tensDigit.sprite = cIH.numbers[(value % 100) / 10];
		onesDigit.sprite = cIH.numbers[value % 10];

		// Initialize the card's info
		information = new cardInfo(value, totalValue, rarity, (colour)rarityIndex);
	}
}
