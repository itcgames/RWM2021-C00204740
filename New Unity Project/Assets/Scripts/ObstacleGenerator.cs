﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public float yOffset;
    private int obstacleNumber;
    public int totalObstacleNumber;
    Transform child;
    private void Start()
    {
        yOffset = 1.5f;
        obstacleNumber = 0;
        totalObstacleNumber = 4;
        for (int i = 0; i< totalObstacleNumber;i++)
        {
            obstacleNumber++;
            SpawnObstacle();
        }
        
    }
    public void SpawnObstacle()
    {

        child = gameObject.transform.GetChild(obstacleNumber);
        float xPos = child.position.x;
        float yPos = child.position.y + yOffset;
        Instantiate(obstacle, new Vector3(xPos, yPos, 0.0f), obstacle.transform.rotation);
        obstacle.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            obstacle.SetActive(true);
        }
    }
}
