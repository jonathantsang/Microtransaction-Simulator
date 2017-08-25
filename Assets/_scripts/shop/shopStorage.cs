using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopStorage : MonoBehaviour {

	public Sprite betterLuckNextTime;
	public Sprite meaninglessUpgrade;
	public Sprite SCOGLotto;
	public Sprite SpeedRunZ;
	public Sprite Mayan2012;
	public Sprite Architect;
	public Sprite TwoTwoTwo;
	public Sprite OhBabyATriple;

	public List<upgrade> Upgrades;
	public Sprite[] upgradeSprites;

	// Use this for initialization
	void Start () {
		Upgrades = new List<upgrade>();
		Upgrades.Add(new upgrade("better luck next time", "Luck++", 200));
		Upgrades.Add(new upgrade("meaninglesss Upgrade", "Doesn't do anything...maybe", 25));
		Upgrades.Add(new upgrade("SCOG Lotto", "Hey guys I found a new website called", 1000));
		Upgrades.Add(new upgrade("SpeedRunZ", "Kill the animals", 9999));
		Upgrades.Add(new upgrade("Mayan2012", "A nice bowl of guac", 200));
		Upgrades.Add(new upgrade("Architect", "and all I got was this degree", 4000));
		Upgrades.Add(new upgrade("TwoTwoTwo", "All I see is", 1997));
		Upgrades.Add(new upgrade("OhBabyATriple", "Quickscope", 60));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
