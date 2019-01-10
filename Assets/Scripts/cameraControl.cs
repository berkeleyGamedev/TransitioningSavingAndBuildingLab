using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    Vector3 initPos; //starting position of the camera
    Transform tr; //transform of the camera
    GameObject player;
    Transform plTr; //transform of the player
    Vector3 playerPos;

    private float scale; //keeps the camera and player at a constant scale
    private float dampen = 1; //how much distance the camera will maintain
    Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f; //how much time the camera is given to catch up to the player
    private float maxSpeed = 10; //fastest speed the camera can travel

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        initPos = tr.position;
        player = GameObject.Find("Player");
        plTr = player.GetComponent<Transform>();
        scale = Screen.width / 723;
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = plTr.position;
        if (checkPos() && playerPos.x > -6)
        {
            //SmoothDamp creates a smooth moving camera and feels a bit more natural
            transform.position = Vector3.SmoothDamp(initPos, new Vector3(playerPos.x, initPos.y, initPos.z), ref velocity, smoothTime * scale, maxSpeed);
            initPos = transform.position;
        }
    }

    //Checks if the camera should start moving based on its position and the variables scale and dampen
    private bool checkPos()
    {
        return playerPos.x > initPos.x + (scale * dampen) || playerPos.x < initPos.x - (scale * dampen);
    }
}
