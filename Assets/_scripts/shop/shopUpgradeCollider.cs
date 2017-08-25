using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopUpgradeCollider : MonoBehaviour {

	private upgrade upgradeInfo;
	private inventoryStorage iS;
	private shopStorage sS;
	private GameObject wholeShopUpgrade;

	// Use this for initialization
	void Start () {
		upgradeInfo = transform.GetComponentInParent<shopUpgrade> ().myData;
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage> ();
		wholeShopUpgrade = transform.parent.gameObject;
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
			// Destroy the shopUpgrade
			Destroy(wholeShopUpgrade);

		} else {
			print ("can't purchase");
		}
	}
}
