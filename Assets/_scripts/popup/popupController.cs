using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupController : MonoBehaviour {

	public GameObject popupPrefab;
	private GameObject Canvas;

	// Use this for initialization
	void Start () {
		Canvas = GameObject.FindGameObjectWithTag ("Canvas").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createPopup(string text, int xPos, int yPos, bool choices){
		GameObject newPopup = Instantiate(popupPrefab, new Vector2(xPos, yPos), Quaternion.identity);
		newPopup.GetComponent<Popup>().setText (text);
		newPopup.GetComponent<Popup> ().choices = choices;
		// If choices is true, turn off the original main collider
		if (choices == true) {
			int mainCollider = 2;
			newPopup.transform.GetChild (2).gameObject.SetActive (false);
		}
		newPopup.transform.SetParent(Canvas.transform);
	}
}
