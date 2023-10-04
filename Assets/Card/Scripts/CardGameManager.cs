using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    //enum is a type that lets us define our own constants
    //in a human readable way
    public enum GameState
    {
        DEAL,
        CHOOSE,
        RESOLVE
    }

    //state is of our enum type, GameState
    //itll keep track of the current state
    public static GameState state;

    //list to hold on to the card's in our player hand
    public List<GameObject> playerHand;

    //how many cards we want in the player's hand
    public int playerHandCount;

    //empty obj that is at the place we want our player's hand to start
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //we start at the dealing state
        state = GameState.DEAL;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case GameState.DEAL:
                //if the player doesn't have 3 cards
                if(playerHand.Count < playerHandCount)
                {
                    //deal a card
                    DealCard();
                } else
                {
                    //otherwise, go to the next state
                    state = GameState.CHOOSE;
                }
                break;
            case GameState.CHOOSE:
                break;
            case GameState.RESOLVE:
                break;
        }
    }

    void DealCard()
    {
        //get the top card from the deck
        GameObject nextCard = DeckManager.deck[DeckManager.deck.Count - 1];
        //local var that hold's the position of the player's hand
        Vector3 newPos = playerPos.transform.position;
        //increment the x position based on how many cards the player has (gives us the gap b/t cards)
        newPos.x = newPos.x + (2f * playerHand.Count);
        //set the card's potisition to our new position
        nextCard.transform.position = newPos;
        //add the card to our hand
        playerHand.Add(nextCard);
        //remove the card from our deck
        DeckManager.deck.Remove(nextCard);
    }
}
