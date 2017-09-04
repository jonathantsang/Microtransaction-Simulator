using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cardInfo {
	public int value;
	public int totalValue;
	public colour rarity;

	public cardInfo(int v, int tV, string r, colour colourInput){
		value = v; 
		totalValue = tV;
		rarity = colourInput;
	}

	public cardInfo(int num){
		value = num;
		totalValue = num;
		rarity = (colour)num;
	}

	public cardInfo(){
		value = 2;
		totalValue = 2;
		rarity = colour.white;
	}

	public colour getRarity(){
		return rarity;
	}

	public int getCardIndex(){
		return (int)rarity;
	}
}
