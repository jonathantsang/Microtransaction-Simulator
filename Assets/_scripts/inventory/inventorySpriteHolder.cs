using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySpriteHolder : MonoBehaviour {

	public Sprite White;
	public Sprite Brown;
	public Sprite Blue;
	public Sprite Purple;
	public Sprite Red;
	public Sprite Green;
	public Sprite Turquoise;
	public Sprite Fuzz;

	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		sprites = new Sprite[] {White, Brown, Blue, Purple, Red, Green, Turquoise, Fuzz};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
