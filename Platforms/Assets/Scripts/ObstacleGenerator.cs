using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    //Obstacle Generator for the Path Object
    public GameObject obstacle;
    public float yOffset;
    private int obstacleNumber;
    public int totalObstacleNumber;
    Transform child;
    public PlatformController platController;
    private void Start()
    {
        SetUp();
    }
    public void SetUp()
    {
        yOffset = 1.5f;
        obstacleNumber = 0;
        totalObstacleNumber = 3;
        for (int i = 0; i < totalObstacleNumber; i++)
        {
            obstacleNumber++;
            SpawnObstacle();
        }
    }
    public void SpawnObstacle()
    {
        if (platController.PlatType() == 1)
        {
            Game.ObstacleGenerated();
            child = gameObject.transform.GetChild(obstacleNumber);
            float xPos = child.position.x;
            float yPos = child.position.y + yOffset;
            Instantiate(obstacle, new Vector3(xPos, yPos, 0.0f), obstacle.transform.rotation);
            obstacle.SetActive(true);
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            obstacle.SetActive(true);
        }
    }
}
