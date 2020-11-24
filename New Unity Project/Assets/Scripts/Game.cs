using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField]
    private GameObject platModel;
    [SerializeField]
    private GameObject movePath;

    private static Game instance;

    private void Start()
    {
        instance = this;

    }
    public Transform[] getTransformArr()
    {
        return movePath.GetComponent<MovementPath>().GetTransformArr();
    }
    public PlatformController GetPlatform()
    {
        return platModel.GetComponent<PlatformController>();
    }
    public MovementPath GetPoints()
    {
        return movePath.GetComponent<MovementPath>();
    }
   
}
