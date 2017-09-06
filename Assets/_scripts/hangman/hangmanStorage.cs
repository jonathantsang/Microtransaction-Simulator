using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hangmanStorage : MonoBehaviour {

	public List<string> words;
	private string word = "";
	private string usedWords = "";

	// Use this for initialization
	void Start () {
		words = new List<string> { "phoenix", "aphrodite", "equinox", "salvation", "metamorphosis" };
		int index = Random.Range (0, words.Count);
		print (index);
		word = words [index];
		print (word);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
