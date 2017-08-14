using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInformationStorage : MonoBehaviour {

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

	void Awake(){
		colours = new Sprite[] {white, brown, blue, purple, red, green, turquoise, fuzz};
		numbers = new Sprite[] {zero, one, two, three, four, five, six, seven, eight, nine};	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
