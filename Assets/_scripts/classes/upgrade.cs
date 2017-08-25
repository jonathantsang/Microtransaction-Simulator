using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade {
	string title;
	string description;
	int price;
	int upgradeIndex;

	public upgrade(string t, string d, int p, int u){
		title = t;
		description = d;
		price = p;
		upgradeIndex = u;
	}

	public string getTitle(){
		return title;
	}

	public string getDescription(){
		return description;
	}

	public int getPrice(){
		return price;
	}

	public int getUpgradeIndex(){
		return upgradeIndex;
	}
}
