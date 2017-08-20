using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryStorage : MonoBehaviour {

	public List<cardInfo> cardInfoList;

	public static inventoryStorage instance;

	// Use this for initialization
	void Start () {
		cardInfoList = new List<cardInfo>();
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

	public void addCard(cardInfo card){
		cardInfoList.Add (card);
		print ("added card");
	}
}
