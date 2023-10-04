using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePlayer : MonoBehaviour
{

    public int speed;

    Vector3 moveDir;

    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        myBody.velocity = moveDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "NPC 1")
        {
            string newDialogue = collision.gameObject.GetComponent<NPCConvo>().myDialogue;
            AdventureGameManager.TriggerConvo(newDialogue, collision.gameObject);
        }
    }
}
