using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    Rigidbody2D rb;
    public int speed;
    int candy;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float vel = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(vel * speed, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //increase candy count and destroy the candy when the player collides with a candy
        if (collision.gameObject.tag.Equals("candy"))
        {
            candy += 1;
            Destroy(collision.gameObject);
        }
    } 

    public int checkCandy()
    {
        return candy;
    }

    public void setCandy(int num)
    {
        candy = num;
    }
}
