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

	private string rarity;
	private int rarityIndex;

	private bool left = true;
	private cardInfo information;

	public bool flipped = false;

	private SpriteRenderer frontSprite;
	private SpriteRenderer backSprite;
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
		Illuminate.SetActive (true);

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
		tensDigit = transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
		onesDigit = transform.GetChild(2).GetChild(1).GetComponent<SpriteRenderer>();

		// Get random value and rarity
		int probability = 999;
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

	void flipCard(){
		// make a separate function that swaps the sprites and the numbers as well
		frontSprite.sortingLayerName = "foreground";
		backSprite.sortingLayerName = "background";
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

		// Choose from 4 shines
		int shineIndex = Random.Range(0, cIH.borders.Length);
		SpriteRenderer IlluminateSprite = transform.GetChild (IlluminateIndex).GetComponent<SpriteRenderer> ();
		IlluminateSprite.sprite = cIH.borders[shineIndex];

		// Turn on or off Illuminate
		Illuminate = transform.GetChild(IlluminateIndex).gameObject;
		Illuminate.SetActive (false);
	}
}
