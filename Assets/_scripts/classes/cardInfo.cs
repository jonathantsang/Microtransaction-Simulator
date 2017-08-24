using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInfo {
	int value;
	int totalValue;
	string rarity;
	int cardIndex;

	public cardInfo(int v, int tV, string r, int cI){
		value = v; 
		totalValue = tV;
		rarity = r;
		cardIndex = cI;
	}

	public string getRarity(){
		return rarity;
	}

	public int getCardIndex(){
		return cardIndex;
	}
}
