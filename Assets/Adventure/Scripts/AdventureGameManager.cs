using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventureGameManager : MonoBehaviour
{
    //object holding all our UI stiff
    public GameObject canvasObj;

    //panel object that has the text object as a child
    static GameObject textObj;
    //text component on the child object
    static TMP_Text textComponent;

    //if we should show text
    public static bool showingText = false;

    //player object that's in the scene
    public GameObject playerObj;
    //will hold the last npc we touched
    public static GameObject npcObj;

    private void Start()
    {
        //get the first child of the canvas (this is the panel)
        textObj = canvasObj.transform.GetChild(0).gameObject;
        //get the text component that's on the first child of the panel
        textComponent = textObj.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    private void Update()
    {
        //if we should show text
        if(showingText)
        {
            //and if the player is past a certain distance from the NPC
            if(Vector3.Distance(playerObj.transform.position, npcObj.transform.position) > 1f)
            {
                //turn off the panel 
                textObj.SetActive(false);
                //we shouldn't show text
                showingText = false;
                //clear out the var tracking the npc we touched
                npcObj = null;
            }
        }
    }

    public static void TriggerConvo(string dialogue, GameObject talkingTo)
    {
        //turn on the panel
        textObj.SetActive(true);
        //set the child's text component to the NPC's dialogue
        textComponent.text = dialogue;
        //we should be showing text
        showingText = true;
        //set to the NPC we just touched
        npcObj = talkingTo;
    }
}
