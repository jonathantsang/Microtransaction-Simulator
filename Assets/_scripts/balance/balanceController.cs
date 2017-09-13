using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balanceController : MonoBehaviour {

	private Text balanceText;
	private inventoryStorage iS;

	// Use this for initialization
	void Start () {
		balanceText = GameObject.FindGameObjectWithTag ("balance").GetComponent<Text> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		setBalanceText ();
	}
	
	// Update is called once per frame
	void Update () {
		setBalanceText ();
	}

	void setBalanceText(){
		float balance = iS.getBalance();
		balance = Mathf.Round(balance * 100f) / 100f;
		string balanceString = "$";
		if (balance < 0) {
			balanceString = "-$";
			balance = -balance;
		}
		balanceString += balance.ToString ();
		balanceText.text = balanceString;
	}
}
