using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpwner : MonoBehaviour
{
    enum MoveType { };
    GameObject platform;
    private IEnumerator<Transform> platformSpwanPoints;
    public MovementPath path;
    public PlatformController plat;
    MoveType moveType;
    private IEnumerator<Transform> pointInPath;
    private int platformNumber;
    public int totalPlatformNumber;
    public void Start()
    {
        
        pointInPath = path.GetNextPoint();
        platform.transform.position = pointInPath.Current.position;
        //get the next point to move to
        pointInPath.MoveNext();
        platformNumber = 0;
        totalPlatformNumber = 4;
        for (int i = 0; i < totalPlatformNumber; i++)
        {
            platformNumber++;
            spawnPlatform();
        }
    }

    public void spawnPlatform()
    {
        Instantiate(platform,platform.transform.position, platform.transform.rotation);
        platform.SetActive(true);
        pointInPath.MoveNext();
        platform.transform.position = pointInPath.Current.position;
    }
}
