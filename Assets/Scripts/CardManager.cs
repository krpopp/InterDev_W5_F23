using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public GameObject cardPrefab;

    public Sprite[] cardFaces;

    public int deckCount;

    public static List<GameObject> deck = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < deckCount; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, gameObject.transform);
            Card newCardScript = newCard.GetComponent<Card>();
            newCardScript.faceSprite = cardFaces[i % 3];
            deck.Add(newCard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
