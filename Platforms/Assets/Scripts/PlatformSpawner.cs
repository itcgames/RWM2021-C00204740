using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    enum MoveType { };
    GameObject platform;
    private IEnumerator<Transform> platformSpwanPoints;
    public Paths path;
    public PlatformController plat;
    MoveType moveType;
    Transform child;
    private int platformNumber;
    public int totalPlatformNumber;
    public void Start()
    {

        
       
        //get the next point to move to
       
        platformNumber = 0;
        totalPlatformNumber = 3;
        for (int i = 0; i < totalPlatformNumber; i++)
        {
            platformNumber++;
            spawnPlatform();
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
