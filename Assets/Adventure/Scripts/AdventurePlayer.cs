using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePlayer : MonoBehaviour
{
    //how fast the player should go
    public int speed;

    //direction the player should move, set through keys
    Vector3 moveDir;

    //this object's body
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //based on key presses, set which way we should be moving
        if(Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1;
        } else if(Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1;
        }
        else
        {
            moveDir.y = 0;
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1;
        } else if(Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1;
        }
        else
        {
            moveDir.x = 0;
        }
    }

    void FixedUpdate()
    {
        //move the player based on our inputs
        //when dealing w/ collisions, we need to use rigidbody movement, even if we're not doing a ton of physics stuff
        myBody.velocity = moveDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we hit an object named NPC 1
        if(collision.gameObject.name == "NPC 1")
        {
            //get that NPC's dialogue
            string newDialogue = collision.gameObject.GetComponent<NPCConvo>().myDialogue;
            //display the dialogue 
            AdventureGameManager.TriggerConvo(newDialogue, collision.gameObject);
        }
    }
}
