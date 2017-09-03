using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cardInfo {
	public int value;
	public int totalValue;
	public string rarity;
	public int cardIndex;

	public cardInfo(int v, int tV, string r, int cI){
		value = v; 
		totalValue = tV;
		rarity = r;
		cardIndex = cI;
	}

	public cardInfo(int num){
		value = num;
		totalValue = num;
		rarity = num.ToString();
		cardIndex = num;
	}

	public cardInfo(){
		value = 2;
		totalValue = 2;
		rarity = 2.ToString();
		cardIndex = 2;
	}

	public string getRarity(){
		return rarity;
	}

	public int getCardIndex(){
		return cardIndex;
	}
}
