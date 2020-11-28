using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
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
}
