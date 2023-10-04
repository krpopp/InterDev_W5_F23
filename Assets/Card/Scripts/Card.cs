using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //sprites for our front and back
    public Sprite faceSprite;
    Sprite backSprite;

    //this card's sprite renderer
    SpriteRenderer myRenderer;

    //tracks if the player has clicked on the card
    bool mouseOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //get my sprite renderer
        myRenderer = GetComponent<SpriteRenderer>();
        //set the back sprite to my current sprite
        backSprite = myRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //use the enum states to determine how the card should behave
        switch(CardGameManager.state)
        {
            case CardGameManager.GameState.DEAL:
                break;
            case CardGameManager.GameState.CHOOSE:
                //if we clicked the card
                if(mouseOver)
                {
                    //set the renderer's sprite to the face sprite
                    myRenderer.sprite = faceSprite;
                }
                break;
            case CardGameManager.GameState.RESOLVE:
                break;
        }
    }

    //event function that runs when the player clicks on this object's collider
    private void OnMouseDown()
    {
        mouseOver = true;
    }
}
