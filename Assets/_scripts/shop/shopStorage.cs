using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopStorage : MonoBehaviour {

	public static shopStorage instance;

	// Keeps track of which upgrades are on
	// 1 on, 0 means off
	public List<int> shopUpgradeFlags;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		const int numberOfUpgrades = 8; // TODO fix hardcode
		shopUpgradeFlags = new List<int> ();
		for (int i = 0; i < numberOfUpgrades; i++) {
			shopUpgradeFlags.Add (0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int checkFlag(int index){
		int shopUpgradeFlagsLength = shopUpgradeFlags.Count;
		if (index < shopUpgradeFlagsLength && index >= 0) {
			return shopUpgradeFlags [index];
		}
		return 0;
	}

	public void turnOnFlag(int index){
		shopUpgradeFlags [index] = 1;
	}

	public void turnOffFlag(int index){
		shopUpgradeFlags [index] = 0;
	}

	public void clearShopFlags(){
		shopUpgradeFlags = new List<int> ();
		const int numberOfUpgrades = 8; // TODO fix hardcode
		for (int i = 0; i < numberOfUpgrades; i++) {
			shopUpgradeFlags.Add (0);
		}
	}

}
