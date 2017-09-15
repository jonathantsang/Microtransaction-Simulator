using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour {

	private audioStorage aS;
	bool big = false;

	// Use this for initialization
	protected virtual void Start() {
		aS = GameObject.FindGameObjectWithTag ("audioStorage").GetComponent<audioStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	virtual public void buttonEffects(){
	}

	void OnMouseDown(){
		aS.playAudio (0);
		if (!big) {
			StartCoroutine (growClick ());
		}
		buttonEffects ();
	}

	IEnumerator growClick()
	{
		big = true;
		Vector3 original = transform.parent.GetChild (0).transform.localScale; // Hardcode the sibling above it
		transform.parent.GetChild (0).transform.localScale += new Vector3 (-0.1f, -0.1f, 0);
		big = true;
		yield return new WaitForSeconds (0.2f);
		transform.parent.GetChild (0).transform.localScale = original;
	}
}
