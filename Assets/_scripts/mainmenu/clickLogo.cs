using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickLogo : MonoBehaviour {

	inventoryStorage iS;

	// Use this for initialization
	void Start () {
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		iS.setFlag ("logo");
	}
}
