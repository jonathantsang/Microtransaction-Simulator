using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[Header("GameData")]
	private int money;
	private int crates;
	private int keys;

	public static GameController instance;

	// Use this for initialization
	void Start () {
		Random.InitState ((int)(System.Environment.TickCount));

		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
