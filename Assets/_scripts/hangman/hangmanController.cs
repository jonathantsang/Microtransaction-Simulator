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
		// Set up blanks
		string blanks = "";
		print (hS.getWordLength ());
		for(int i = 0; i < hS.getWordLength(); i++){
			blanks += "_ ";
		}
		print (blanks);
		Blanks.text = blanks;
		WordsUsed.text = "";
	}

	public void Input(char c){
		print (c);
		// TODO missing letters
		bool atLeastOne = false;
		for (int i = 0; i < hS.getWordLength (); i++) {
			if (hS.getCharAtIndex (i) == c) {
				atLeastOne = true;
				hS.solveCharAtIndex (i);

			}
		}
		updateText ();
	}

	void updateText(){
		string answer = "";
		string newText = "";
		for(int i = 0; i < hS.getWordLength(); i++){
			if (hS.solvedSoFar[i] != ' ') {
				answer += hS.getCharAtIndex (i);
				newText += answer [i] + " ";
			} else {
				answer += " ";
				newText += "_ ";
			}
		}
		hS.solvedSoFar = answer;
		Blanks.text = newText;
	}
}
