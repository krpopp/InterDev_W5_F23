using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGrow : MonoBehaviour
{
    public float timeToGrow;
    float timeToGrowCounter;

    public GameObject[] cloudSizes;

    int timesGrown = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timesGrown < cloudSizes.Length - 1)
        { 
            timeToGrowCounter += Time.deltaTime;
            if (timeToGrowCounter > timeToGrow)
            {
                GrowCloud();
                timeToGrowCounter = 0;
            }
        }
    }

    void GrowCloud()
    {
        cloudSizes[timesGrown].SetActive(false);
        timesGrown += 1;
        cloudSizes[timesGrown].SetActive(true);
    }
}
