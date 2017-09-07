using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStorage : MonoBehaviour {

	public static audioStorage instance;

	public AudioClip clickSound;
	public AudioClip cashSound;
	public AudioClip shineSound;
	public AudioClip jingleSound;
	public AudioClip[] audioFiles;

	private AudioSource audioS;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);

		audioS = GetComponent<AudioSource> ();
		audioFiles = new AudioClip[] {clickSound, cashSound, shineSound, jingleSound};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playAudio(int index){
		int audioFilesLength = audioFiles.Length;
		if(index < audioFilesLength && index >= 0){
			audioS.clip = audioFiles [index];
			audioS.Play ();
		}
	}
}
