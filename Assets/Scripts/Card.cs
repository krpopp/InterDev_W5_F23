using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public Sprite faceSprite;
    Sprite backSprite;

    SpriteRenderer myRenderer;

    bool mouseOver = false;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        backSprite = myRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.state)
        {
            case GameManager.GameState.DEAL:
                break;
            case GameManager.GameState.CHOOSE:
                if(mouseOver)
                {
                    myRenderer.sprite = faceSprite;
                }
                break;
            case GameManager.GameState.RESOLVE:
                break;
        }
    }

    private void OnMouseDown()
    {
        mouseOver = true;
    }
}
