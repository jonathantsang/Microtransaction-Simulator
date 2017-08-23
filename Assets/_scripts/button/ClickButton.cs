using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	virtual public void buttonEffects(){
	}

	void OnMouseDown(){
		print ("down");
		StartCoroutine (growClick());
		buttonEffects ();
	}

	IEnumerator growClick()
	{
		Vector3 original = transform.parent.GetChild (0).transform.localScale; // Hardcode the sibling above it
		transform.parent.GetChild (0).transform.localScale += new Vector3(0.1f, 0.1f, 0);
		yield return new WaitForSeconds(0.4f);
		transform.parent.GetChild (0).transform.localScale = original;
	}
}
