using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    //premade card object
    public GameObject cardPrefab;

    //all the face sprites a card can have
    public Sprite[] cardFaces;

    //how many cards should be in our deck
    public int deckCount;

    //list holding on to all the cards in the deck
    public static List<GameObject> deck = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //loop for however many cards we want in the deck
        for(int i = 0; i < deckCount; i++)
        {
            //make a new card and child it to this object
            GameObject newCard = Instantiate(cardPrefab, gameObject.transform);
            //get that new card's card script
            Card newCardScript = newCard.GetComponent<Card>();
            //change the sprite on the card using mod 3 (this will iterate through all 3 sprites)
            newCardScript.faceSprite = cardFaces[i % 3];
            //add this new card to the deck list
            deck.Add(newCard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
