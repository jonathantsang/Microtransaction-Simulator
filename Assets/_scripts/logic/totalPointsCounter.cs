using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalPointsCounter : MonoBehaviour {

	private Text pointsText;
	private GameObject cardHolder;

	private int totalPoints;
	private audioStorage aS;

	// Use this for initialization
	void Start () {
		aS = GameObject.FindGameObjectWithTag ("audioStorage").GetComponent<audioStorage> ();
		// Find the pointsText
		pointsText = GetComponent<Text>();
		cardHolder = GameObject.FindGameObjectWithTag ("cards");
		notify("clear");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void notify(string type) {
		if (type == "count") {
			totalPoints = 0;
			// Loop through children cards and find if they are all flipped
			if (cardHolder != null){
				for (int i = 0; i < cardHolder.transform.childCount; i++) {
					if (cardHolder.transform.GetChild (i).GetComponent<Card> ().flipped != true) {
						return;
					}
					totalPoints += cardHolder.transform.GetChild (i).GetComponent<Card> ().totalValue;
				}

			}
			// If they are all flipped, count up the score
			countUpScore ();
		} else if (type == "clear") {
			pointsText.text = "0";
		}
	}

	void countUpScore(){
		pointsText.text = "0";
		StartCoroutine (Counter());
	}


	IEnumerator Counter()
	{
		int score = 0;
		while (score < totalPoints)
		{
			if (score + 100 > totalPoints) {
				score += (totalPoints - score);
			} else {
				score += 100;
			}
			pointsText.text = score.ToString();
			yield return new WaitForSeconds(1/totalPoints);
		}
		int cashSound = 1; // TODO hardcoded 1 for cashSound
		aS.playAudio (cashSound);
	}
}
