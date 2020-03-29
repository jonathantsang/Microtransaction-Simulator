using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuInput : MonoBehaviour {

	// Hard code start and quit text
	Text startGame;
	Text Quit;

	// 0 is startGame, 1 is Quit
	int selected;
	Text[] choices;

	// Use this for initialization
	void Start () {
		startGame = GameObject.FindGameObjectWithTag ("menu").transform.GetChild (0).GetComponent<Text>();
		Quit = GameObject.FindGameObjectWithTag ("menu").transform.GetChild (1).GetComponent<Text>();
		choices = new Text[] {startGame, Quit};

		// Default start is red
		startGame.color = new Color (1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
			switchChoice ();
			updateChoice ();
			// Move it up
		} else if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			// Move it down
			switchChoice ();
			updateChoice ();
		} else if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
			// Hardcode choices for options
			if (selected == 0) {
				// Start game
				print("start game");
				SceneManager.LoadScene("OpenCrate");
			} else if (selected == 1) {
				print ("quit game");
				Application.Quit();
			}
		}
	}

	// Switches the choice (will need to be updated for more choices)
	void switchChoice(){
		if (selected == 1) {
			selected = 0;
		} else if (selected == 0) {
			selected = 1;
		}
	}

	// Updates the red text
	void updateChoice(){
		// selected is already updated to the new choice index
		choices [selected].color = new Color (1, 0, 0);
		// TODO hardcoded to turn the other one to black
		choices[Mathf.Abs(selected - 1)].color = new Color(0,0,0);
	}
}
