using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avocadoTextMovement : MonoBehaviour {

	float timer = 0f;
	float timeLength = 0.3f;
	Rigidbody2D rb2d;
	bool left = true;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		destroyText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void destroyText(){
		while (timer < timeLength) {
			timer += Time.deltaTime;
			if (left) {
				left = false;
				rb2d.AddForce (new Vector2 (0, 0.6f));
			} else {
				left = true;
				rb2d.AddForce (new Vector2 (0, 0.6f));
			}
		}
		print ("destroyed");
		Destroy (gameObject, 3);
	}
}
