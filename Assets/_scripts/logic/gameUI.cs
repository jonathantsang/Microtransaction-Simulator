using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUI : MonoBehaviour {

	private GameObject banner;

	private Text wallet;
	private Text crates;
	private Text keys;

	// Use this for initialization
	void Start () {
		banner = GameObject.FindGameObjectWithTag ("banner");
		if (banner != null) {
			wallet = banner.transform.GetChild (0).GetComponent<Text> ();
			crates = banner.transform.GetChild (1).GetComponent<Text> ();
			keys = banner.transform.GetChild (2).GetComponent<Text> ();
			wallet.text = "Wallet: $ " + 0;
			crates.text = "Crates: " + 0;
			keys.text = "Keys: " + 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
