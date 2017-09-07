using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInformationHolder : MonoBehaviour {

	public Sprite fuzz;
	public Sprite turquoise;
	public Sprite green;
	public Sprite red;
	public Sprite purple;
	public Sprite blue;
	public Sprite brown;
	public Sprite white;
	public Sprite back;
	[HideInInspector]
	public Sprite[] colours;

	public Sprite zero;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	[HideInInspector]
	public Sprite[] numbers;

	public Sprite bronzeBorder;
	public Sprite silverBorder;
	public Sprite goldBorder;
	public Sprite deepBorder;
	[HideInInspector]
	public Sprite[] borders;

	[HideInInspector]
	public int[] chances;
	public int[] compiledChances;
	public int[] improvedChances;
	public int[] compiledImprovedChances;

	shopStorage sS;

	void Awake(){
		colours = new Sprite[] {white, brown, blue, purple, red, green, turquoise, fuzz};
		numbers = new Sprite[] {zero, one, two, three, four, five, six, seven, eight, nine};
		borders = new Sprite[] {bronzeBorder, silverBorder, goldBorder, deepBorder };

		// chance is raw percentage, compiled chance is previous amounts as well
		chances = new int[] {400, 300, 100, 80, 70, 30, 10, 5, 3, 2};
		compiledChances = new int [] {400, 700, 800, 880, 950, 980, 990, 995, 998, 999};
		improvedChances = new int[] {200, 200, 200, 100, 100, 100, 80, 19};
		compiledImprovedChances = new int [] { 200, 400, 600, 700, 800, 900, 980, 999 };


		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage> ();

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getChance(int index){
		// Luck upgrade is index 2
		// TODO make it dynamic
		const int luckUpgradeIndex = 2;
		// If the flag is set, use the improved, else use the regular
		if(sS.checkFlag(luckUpgradeIndex) == 1){
			return compiledImprovedChances[index];
		} else {
			return compiledChances[index];
		}
	}
}
