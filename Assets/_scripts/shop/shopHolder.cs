using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopHolder : MonoBehaviour {

	// Stores data and the flags

	public Sprite betterLuckNextTime;
	public Sprite meaninglessUpgrade;
	public Sprite SCOGLotto;
	public Sprite SpeedRunZ;
	public Sprite Mayan2012;
	public Sprite Architect;
	public Sprite TrophyRoom;
	public Sprite CardTrick;

	public List<upgrade> Upgrades;
	public Sprite[] upgradeSprites;

	void Awake(){
		upgradeSprites = new Sprite[] {meaninglessUpgrade, CardTrick, betterLuckNextTime, Mayan2012, SCOGLotto, TrophyRoom, Architect, SpeedRunZ};

		Upgrades = new List<upgrade>();
		Upgrades.Add(new upgrade("Meaninglesss Upgrade", "Doesn't do anything...maybe", 25, 0));
		Upgrades.Add(new upgrade("Card Trick", "Now you see me", 60, 1));
		Upgrades.Add(new upgrade("Better luck next time", "Luck++", 200, 2));
		Upgrades.Add(new upgrade("Mayan2012", "A nice bowl of guac", 300, 3));
		Upgrades.Add(new upgrade("SCOG Lotto", "Hey guys I found a new website called", 1000, 4));
		Upgrades.Add(new upgrade("Trophy Room", "All I do is win", 1997, 5));
		Upgrades.Add(new upgrade("Architect", "and all I got was this degree", 4000, 6));
		Upgrades.Add(new upgrade("SpeedRunZ", "Kill the animals", 9999, 7));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
