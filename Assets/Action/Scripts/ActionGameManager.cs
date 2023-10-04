using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGameManager : MonoBehaviour
{
    //premade cloud object
    public GameObject cloudPrefab;

    //min and max clouds we can have on screen
    public int maxClouds;
    public int minClouds;

    //timer stuff for making a new cloud
    public float timeToCloud;
    float timeToCloudCounter;

    //area we want to spawn clouds in
    BoxCollider2D worldBounds;

    //range of area we want to spawn clouds in
    Vector3 minBounds;
    Vector3 maxBounds;

    //list to hold all our clouds
    List<GameObject> allClouds = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //the box collider on this object which is setting our spawnable area
        worldBounds = GetComponent<BoxCollider2D>();
        //min and max range that clouds can spawn in
        minBounds = worldBounds.bounds.min;
        maxBounds = worldBounds.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        //increment the counter
        timeToCloudCounter += Time.deltaTime;
        //if we reach the max of the timer OR if we do not have enough clouds
        if (timeToCloudCounter > timeToCloud || allClouds.Count < minClouds)
        {
            //and if we have less than the max amount of clouds
            if (allClouds.Count < maxClouds)
            {
                //make a cloud and reset the timer
                MakeACloud();
                timeToCloudCounter = 0;
            }
        }
    }

    void MakeACloud()
    {
        //create a new cloud
        GameObject newCloud = Instantiate(cloudPrefab);
        //create a vec 3 w/ random values w/i our box collider
        Vector3 newPos = new Vector3(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.y, maxBounds.y), 0f);
        //set the cloud's position to this new, random pos
        newCloud.transform.position = newPos;
        //add the cloud to the list
        allClouds.Add(newCloud);
    }
}
