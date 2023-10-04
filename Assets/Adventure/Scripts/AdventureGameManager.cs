using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventureGameManager : MonoBehaviour
{
    public GameObject canvasObj;

    static GameObject textObj;
    static TMP_Text textComponent;

    public static bool showingText = false;

    public GameObject playerObj;
    public static GameObject npcObj;

    private void Start()
    {
        textObj = canvasObj.transform.GetChild(0).gameObject;
        textComponent = textObj.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if(showingText)
        {
            if(Vector3.Distance(playerObj.transform.position, npcObj.transform.position) > 1f)
            {
                textObj.SetActive(false);
                showingText = false;
                npcObj = null;
            }
        }
    }

    public static void TriggerConvo(string dialogue, GameObject talkingTo)
    {
        textObj.SetActive(true);
        textComponent.text = dialogue;
        showingText = true;
        npcObj = talkingTo;
    }
}
