using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avocadoController : MonoBehaviour {

	public GameObject avocado;
	shopStorage sS;

	// Use this for initialization
	void Start () {
		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage> ();
		// avocado is upgrade index 3
		const int avocadoUpgradeFlagIndex = 3;
		if (sS.checkFlag (avocadoUpgradeFlagIndex) == 1) {
			Instantiate (avocado, new Vector2 (Random.Range (1, 7), Random.Range (1, 7)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
