using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour {

	private audioStorage aS;

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
		StartCoroutine (growClick());
		buttonEffects ();
	}

	IEnumerator growClick()
	{
		Vector3 original = transform.parent.GetChild (0).transform.localScale; // Hardcode the sibling above it
		transform.parent.GetChild (0).transform.localScale += new Vector3(-0.1f, -0.1f, 0);
		yield return new WaitForSeconds(0.2f);
		transform.parent.GetChild (0).transform.localScale = original;
	}
}
