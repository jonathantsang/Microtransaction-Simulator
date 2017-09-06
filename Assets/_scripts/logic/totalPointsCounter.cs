using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalPointsCounter : MonoBehaviour {

	private Text pointsText;
	private GameObject cardHolder;

	private int totalPoints;
	private audioStorage aS;
	private inventoryStorage iS;

	// Use this for initialization
	void Start () {
		aS = GameObject.FindGameObjectWithTag ("audioStorage").GetComponent<audioStorage> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();

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
			// TODO technically totalPointsCounter shouldn't add to cardOpenList, but it can
			addToCardOpenList();
			// If they are all add to the cardOpenList and flipped count up the score and make it increase text amount
			countUpScore ();
		} else if (type == "clear") {
			pointsText.text = "0";
		}
	}

	void countUpScore(){
		pointsText.text = "0";
		StartCoroutine (Counter());
	}

	void addToCardOpenList(){
		cardOpen cardOpenCollection = new cardOpen();
		for (int i = 0; i < cardHolder.transform.childCount; i++) {
			// Add each card's "cardInfo" to the list for the cardOpen
			cardOpenCollection.addToCardsOpened (cardHolder.transform.GetChild (i).GetComponent<Card> ().getCardInfo ());
		}
		// Add the final card collection and total value to the list
		cardOpenCollection.totalCardOpenValue = totalPoints;
		iS.cardOpenList.Add (cardOpenCollection);
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
