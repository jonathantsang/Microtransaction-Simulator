using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalPointsCounter : MonoBehaviour {

	private Text pointsText;
	private GameObject cardHolder;

	private int totalPoints;

	// Use this for initialization
	void Start () {
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
			print ("all flipped");
			print ("total" + totalPoints);
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
	}
}
