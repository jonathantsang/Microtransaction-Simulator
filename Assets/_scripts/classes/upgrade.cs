using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade {
	string title;
	string description;
	int price;

	public upgrade(string t, string d, int p){
		title = t;
		description = d;
		price = p;
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
}
