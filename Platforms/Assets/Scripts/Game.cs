using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public bool playerOnPlat = false;
    public bool backToOriginalRotation = false;
    public bool onBreakablePlatform = false;
    public bool breakablePlatformDestroyed = false;
    public bool rotating = false;
    public bool obstacleGenerated = false;

    [SerializeField]
    private GameObject platModel;
    [SerializeField]
    private GameObject movePath;
    [SerializeField]
    private GameObject player;


    private static Game instance;

    private void Start()
    {
        instance = this;

    }
    public static void isRotating()
    {
        instance.rotating = true;
    }
    public static void ObstacleGenerated()
    {
        instance.obstacleGenerated = true;
    }
    public static void OnBreakablePlat()
    {
        instance.onBreakablePlatform = true;
    }
    public static void breabablePlatDestroyed()
    {
        instance.breakablePlatformDestroyed = true;
    }

    public static void playerIsOnPlat()
    {
        instance.playerOnPlat = true;
    }
    public static void playerIsNotPlat()
    {
        instance.playerOnPlat = false;
    }
    public static void BackToOgRotation()
    {
        instance.backToOriginalRotation = true;
    }
    public static void NotBackToOgRotation()
    {
        instance.backToOriginalRotation = false;
    }
    public Transform[] getTransformArr()
    {
        return movePath.GetComponent<Paths>().GetTransformArr();
    }
    public PlatformController GetPlatform()
    {
        return platModel.GetComponent<PlatformController>();
    }
    public Paths GetPoints()
    {
        return movePath.GetComponent<Paths>();
    }
    public PlayerController GetPlayer()
    {
        return player.GetComponent<PlayerController>();
    }
    public ObstacleGenerator GetObstacle()
    {
        return movePath.GetComponent<ObstacleGenerator>();
    }
}
