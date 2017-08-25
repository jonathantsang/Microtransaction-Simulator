using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopUpgradeCollider : MonoBehaviour {

	upgrade upgradeInfo;
	inventoryStorage iS;
	shopStorage sS;

	// Use this for initialization
	void Start () {
		upgradeInfo = transform.GetComponentInParent<shopUpgrade> ().myData;
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnMouseDown(){
		if (upgradeInfo.getPrice () <= iS.Balance) {
			print ("can purchase");
			print ("execute " + upgradeInfo.getTitle());
			sS.turnOnFlag (upgradeInfo.getUpgradeIndex ());
			print ("turned on");
		} else {
			print ("can't purchase");
		}
	}
}
