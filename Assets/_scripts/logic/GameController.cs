using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private inventoryStorage iS;

	// Use this for initialization
	void Start () {
		Random.InitState ((int)(System.Environment.TickCount));

		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.T)) {
			iS.Balance += 1000;
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
