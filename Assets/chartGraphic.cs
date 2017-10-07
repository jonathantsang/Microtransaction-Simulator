using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartGraphic : MonoBehaviour {


	public Sprite regularChart;
	public Sprite lucidChart;

	private inventoryStorage iS;
	private SpriteRenderer spriteR;

	// Use this for initialization
	void Start () {
		spriteR = GetComponent<SpriteRenderer> ();
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		// Makes graphic different if lucid once
		if (iS.checkFlag ("lucid") > 0) {
			spriteR.sprite = lucidChart;
		} else {
			spriteR.sprite = regularChart;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
