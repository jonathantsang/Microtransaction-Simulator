using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    private GameObject shop;
    private GameObject shopMenu;
    private GameObject counter;
    // Start is called before the first frame update
    void Start()
    {
      this.GetComponent<Button>().onClick.AddListener(buttonEffects);

      shop = GameObject.FindGameObjectWithTag ("shop").gameObject;
  		shop.SetActive (false);
  		counter = GameObject.FindGameObjectWithTag ("counter").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonEffects(){
  		// Show the menu
  		shop.SetActive(true);
  		// Also close totalPointsCounter
  		counter.SetActive(false);
  	}
}
