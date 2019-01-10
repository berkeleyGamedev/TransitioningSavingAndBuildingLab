using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class candy : MonoBehaviour {

    public Text candyText; //UI element that displays the number of candies
    GameObject player;
    playerController controller;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        controller = player.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Continually updates the UI text for the number of candies collected
        candyText.text = "Candies: " + controller.checkCandy().ToString();
	}
}
