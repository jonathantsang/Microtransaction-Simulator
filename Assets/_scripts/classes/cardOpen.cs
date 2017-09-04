using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cardOpen {
	public int totalCardOpenValue;
	// The list should only contain 4 cards (since that is the amount for each pack), not hardcoded in
	public List<cardInfo> cardsOpened;

	public cardOpen(){
		cardsOpened = new List<cardInfo> ();
	}

	public void addToCardsOpened(cardInfo cardToAdd){
		cardsOpened.Add(cardToAdd);
	}

}
