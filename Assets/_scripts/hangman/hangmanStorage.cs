using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hangmanStorage : MonoBehaviour {

	public List<string> words;
	private string word;

	public string solvedSoFar;
	public string usedWords;

	// Use this for initialization
	void Start () {

		word = "";
		solvedSoFar = "";
		usedWords = "";

		words = new List<string> { "phoenix", "aphrodite", "equinox", "salvation", "metamorphosis", "inconceivable", "equestrian", "lycanthropy", "serendepity", "heinous" };
		int index = Random.Range (0, words.Count);
		word = words [index];
		// prep solvedSoFar
		for(int i = 0; i < getWordLength(); i++){
			solvedSoFar += " ";
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public int getWordLength(){
		return word.Length;
	}

	public char getCharAtIndex(int index){
		if (index >= 0 && index < getWordLength ()) {
			return word [index]; 
		}
		return 'a';
	}

	public void solveCharAtIndex(int index){
		// Have to rebuild the string since it is not immutable
		string newSolvedSoFar = "";
		for (int i = 0; i < getWordLength (); i++) {
			// If it is already there solve it
			if (solvedSoFar[i] != ' ') {
				newSolvedSoFar += getCharAtIndex (i);
			} else if (i == index) {
				newSolvedSoFar += word [index];
			} else {
				newSolvedSoFar += " ";
			}
		}
		solvedSoFar = newSolvedSoFar;
	}

	public bool checkWon(){
		return word == solvedSoFar;
	}
}
