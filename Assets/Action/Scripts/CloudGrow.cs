using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGrow : MonoBehaviour
{
    //timer for when to grow clouds
    public float timeToGrow;
    float timeToGrowCounter;

    //holding each cloud size
    public GameObject[] cloudSizes;

    //how many times we've grown
    int timesGrown = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if we haven't fully grown
        if (timesGrown < cloudSizes.Length - 1)
        { 
            //increment the timer
            timeToGrowCounter += Time.deltaTime;
            //if the timer has hit the limit
            if (timeToGrowCounter > timeToGrow)
            {
                //grow this cloud and reset the timer
                GrowCloud();
                timeToGrowCounter = 0;
            }
        }
    }

    void GrowCloud()
    {
        //turn off the current cloud
        cloudSizes[timesGrown].SetActive(false);
        //increase the index for how big we should grow
        timesGrown += 1;
        //turn on the next, bigger cloud
        cloudSizes[timesGrown].SetActive(true);
    }
}
