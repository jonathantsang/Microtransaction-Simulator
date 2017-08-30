using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuChlseaTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Fade());
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	IEnumerator Fade(){
		yield return new WaitForSeconds (3);
		this.gameObject.SetActive (false);

	}

}
