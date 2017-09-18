using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucidGraphic : MonoBehaviour {

	public Sprite skull;
	public Sprite off;

	private SpriteRenderer SR;

	float timer;
	float timeLength = 1f;

	private inventoryStorage iS;

	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer> ();
		SR.sprite = off;
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > timeLength) {
			timer = 0;
			checkLucid ();
		}
		timer += Time.deltaTime;
	}

	void checkLucid(){
		if(iS.checkFlag("lucid") > 0){
			SR.sprite = skull;
		}
	}

}
