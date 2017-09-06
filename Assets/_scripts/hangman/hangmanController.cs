using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hangmanController : MonoBehaviour {

	public int tries;
	public bool won;

	private int blanksIndex = 0;
	private int wordsUsedIndex = 1;
	private int hangmanStorageIndex = 2;

	private GameObject keyItems;
	private GameObject canvas;
	private hangmanStorage hS;
	private Text Blanks;
	private Text WordsUsed;

	// Use this for initialization
	void Start () {
		keyItems = GameObject.FindGameObjectWithTag ("keyItems").gameObject;
		canvas = GameObject.FindGameObjectWithTag ("Canvas").gameObject;
		hS = keyItems.transform.GetChild (hangmanStorageIndex).GetComponent<hangmanStorage> ();
		Blanks = canvas.transform.GetChild (blanksIndex).GetComponent<Text> ();
		WordsUsed = canvas.transform.GetChild (wordsUsedIndex).GetComponent<Text> ();

		// TODO fix hardcode
		tries = 5;

		Setup ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Setup(){
		
	}
}
