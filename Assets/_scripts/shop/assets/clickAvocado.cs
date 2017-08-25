using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAvocado : MonoBehaviour {

	public GameObject floatingText;
	private inventoryStorage iS;

	// Use this for initialization
	void Start () {
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		Destroy (this.transform.parent.gameObject, 60);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// Play cash music
		iS.Balance += 300;
		Instantiate (floatingText, transform.position, Quaternion.identity);
		Disappear ();
	}
		

	void Disappear(){
		Destroy (this.transform.parent.gameObject);
	}
}
