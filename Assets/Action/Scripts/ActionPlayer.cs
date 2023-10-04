using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    //vars to hold which key to press
    //lets us use this single script for two players
    public KeyCode leftKey;
    public KeyCode rightKey;

    //tunable vars for phsyics
    public float xAccel;
    public float gravity;
    public float bounceVel;

    //bools to track if we should move left/right
    bool goLeft;
    bool goRight;

    //this object's body
    Rigidbody2D myBody;

    //bool if we should bounce
    bool bounce;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //switch booleans based on key input
        if (Input.GetKey(leftKey))
        {
            goLeft = true;
        }
        else
        {
            goLeft = false;
        }

        if(Input.GetKey(rightKey))
        {
            goRight = true;
        }
        else 
        {
            goRight = false;
        }
    }

    private void FixedUpdate()
    {
        //get our current velocity
        Vector3 newVel = myBody.velocity;

        //slow down the x a bit
        newVel.x *= 0.9f;

        //pull down our player w/ gravity
        newVel.y += gravity;
        
        //if we should bounce
        if(bounce)
        {
            //add some y velocity and turn off bounce
            newVel.y += bounceVel;
            bounce = false;
        }

        //if we should go left/right, add to the correct x vel
        if(goLeft)
        {
            newVel.x -= xAccel;
        } else if(goRight)
        {
            newVel.x += xAccel;
        }

        //set our velocity to the newly calculated veloctiy
        myBody.velocity = newVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we hit a cloud, flip the switch that'll tell us to bounce
        if (collision.gameObject.tag == "Cloud")
        {
            bounce = true;
        }
    }
}
