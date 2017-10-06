using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSymbol : MonoBehaviour {

	public Sprite musicOnSprite;
	public Sprite musicOffSprite;
	private SpriteRenderer spriteR;
	// This is used for checking if buttons should make noise and sparkle as well
	public bool musicOn;

	private AudioSource aS;
	public AudioClip menuMusic;

	private inventoryStorage iS;

	// Use this for initialization
	void Start () {
		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage> ();
		spriteR = GetComponent<SpriteRenderer> ();
		aS = GetComponent<AudioSource> ();
		if (iS.checkFlag ("soundOn") == 1) {
			turnOnMusic ();
		} else {
			turnOffMusic ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (musicOn) {
			iS.setFlag ("soundOn");
			turnOffMusic ();
		} else {
			iS.setFlag ("soundOn");
			turnOnMusic ();
		}
	}

	void turnOnMusic(){
		musicOn = true;
		spriteR.sprite = musicOnSprite;
		aS.Play ();
	}

	void turnOffMusic(){
		musicOn = false;
		spriteR.sprite = musicOffSprite;
		aS.Pause ();
	}

	public bool checkMusicOn(){
		return musicOn;
	}

}
