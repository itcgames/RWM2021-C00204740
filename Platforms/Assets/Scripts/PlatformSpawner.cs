using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    private int platformNumber;
    public int totalPlatformNumber;
    Transform child;
    public void Start()
    {
       
        platformNumber = 0;
        totalPlatformNumber = 4;
        for (int i = 0; i < totalPlatformNumber; i++)
        {
            spawnPlatform();
            platformNumber++;
        }
    }

    public void spawnPlatform()
    {
        child = gameObject.transform.GetChild(platformNumber);
        float xPos = child.position.x;
        float yPos = child.position.y;
        Instantiate(platform, new Vector3(xPos, yPos, 0.0f), platform.transform.rotation);
        platform.SetActive(true);
       
    }
}
