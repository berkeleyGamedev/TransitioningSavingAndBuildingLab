using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

    GameObject player;
    Transform playerTR;
    Vector2 playerPos;
    public GameObject mapPiece;
    GameObject prevMap;
    GameObject currMap;
    GameObject nextMap;

    public GameObject candyPrefab;
    GameObject currCandy;

    private void Awake() {
        player = GameObject.Find("Player");

        //creates the first 3 platforms for the player
        prevMap = Instantiate(mapPiece, new Vector3(-36, 0), new Quaternion());
        currMap = Instantiate(mapPiece, new Vector3(0, 0), new Quaternion());
        nextMap = Instantiate(mapPiece, new Vector3(36, 0), new Quaternion());

        //creates 5 candies at pseudorandom and increasingly further distances with random color
        for (int x = 1; x < 6; x++)
        {
            currCandy = Instantiate(candyPrefab, new Vector2(x * 5 * Random.Range(0.0f, 1.0f), -1.4f), new Quaternion());
            currCandy.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }
    }

	// Use this for initialization
	void Start () {
        playerTR = player.GetComponent<Transform>();
        playerPos = playerTR.position;
	}

    // Update is called once per frame
    void Update()
    {
        playerPos = playerTR.position;
        modifyMap();
        spawnCandy();
    }

    //checks if it is necessary to spawn/despawn pieces of the map based on the position of the player's transform
    void modifyMap()
    {
        float currMapXPos = currMap.GetComponent<Transform>().position.x;
        if (playerPos.x > currMapXPos + 36)
        {
            Destroy(prevMap);
            prevMap = currMap;
            currMap = nextMap;
            nextMap = Instantiate(mapPiece, new Vector3(currMapXPos + 72, 0), new Quaternion());
        }
        else if (playerPos.x < currMapXPos - 36)
        {
            Destroy(nextMap);
            nextMap = currMap;
            currMap = prevMap;
            prevMap = Instantiate(mapPiece, new Vector3(currMapXPos - 72, 0), new Quaternion());
        }
    }

    //checks if more candies need to be spawned based on the distance between the last spawned candy and the player
    void spawnCandy()
    {
        if (currCandy)
        {
            float currCandyXPos = currCandy.GetComponent<Transform>().position.x;
            if (playerPos.x > currCandyXPos - 10)
            {
                currCandy = Instantiate(candyPrefab, new Vector2(playerPos.x + 10 + (10 * Random.Range(-1.0f, 1.0f)), -1.4f), new Quaternion());
                currCandy.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            }
        }
        else
        {
            currCandy = Instantiate(candyPrefab, new Vector2(playerPos.x + 10 + (7 * Random.Range(-1.0f, 1.0f)), -1.4f), new Quaternion());
            currCandy.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }
    }
}
