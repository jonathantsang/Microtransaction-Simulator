﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWon : MonoBehaviour {

	float timer = 0f;
	float timeLength = 0.3f;

	private inventoryStorage iS;
	public GameObject winButton;
	private GameObject winSpawned;

	// Use this for initialization
	void Start () {
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < timeLength) {
			if (iS.Balance > 9999){
				if (winSpawned == null) {
					winSpawned = Instantiate (winButton, new Vector2 (0, 0), Quaternion.identity);
				}
			}
			timer = 0;
		}
		timer += Time.deltaTime;
	}
}