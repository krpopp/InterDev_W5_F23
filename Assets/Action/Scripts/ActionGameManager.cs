using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGameManager : MonoBehaviour
{

    public GameObject cloudPrefab;

    public int maxClouds;
    public int minClouds;

    public float timeToCloud;
    float timeToCloudCounter;

    BoxCollider2D worldBounds;

    Vector3 minBounds;
    Vector3 maxBounds;

    List<GameObject> allClouds = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        worldBounds = GetComponent<BoxCollider2D>();
        minBounds = worldBounds.bounds.min;
        maxBounds = worldBounds.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeToCloudCounter);
        timeToCloudCounter += Time.deltaTime;
        if (timeToCloudCounter > timeToCloud || allClouds.Count < minClouds)
        {
            if (allClouds.Count < maxClouds)
            {
                MakeACloud();
                timeToCloudCounter = 0;
            }
        }
    }

    void MakeACloud()
    {
        GameObject newCloud = Instantiate(cloudPrefab);
        Vector3 newPos = new Vector3(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.y, maxBounds.y), 0f);
        newCloud.transform.position = newPos;
        allClouds.Add(newCloud);
    }
}
