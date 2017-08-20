using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInfo {
	int value;
	int totalValue;
	string rarity;

	public cardInfo(int v, int tV, string r){
		value = v; 
		totalValue = tV;
		rarity = r;
	}

	public string getRarity(){
		return rarity;
	}
}
