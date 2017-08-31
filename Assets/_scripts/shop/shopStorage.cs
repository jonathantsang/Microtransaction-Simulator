using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopStorage : MonoBehaviour {

	public static shopStorage instance;


	// Keeps track of which upgrades are on
	// 1 on, 0 means off
	Dictionary<int, int> shopUpgradeFlags;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		const int numberOfUpgrades = 8;
		shopUpgradeFlags = new Dictionary<int, int> ();
		for (int i = 0; i < numberOfUpgrades; i++) {
			shopUpgradeFlags [i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int checkFlag(int index){
		return shopUpgradeFlags[index];
	}

	public void turnOnFlag(int index){
		shopUpgradeFlags [index] = 1;
	}

	public void turnOffFlag(int index){
		shopUpgradeFlags [index] = 0;
	}

}
