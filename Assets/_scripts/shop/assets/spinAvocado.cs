using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinAvocado : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Rotate ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Rotate(){
		while (true) {
			transform.Rotate (0, 0, -2);
			yield return new WaitForSeconds (1 / 100);
		}
	}
}
