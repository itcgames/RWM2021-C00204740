using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField]
    private GameObject platModel;

    private static Game instance;

    private void Start()
    {
        instance = this;
    }
    public PlatformController GetPlatform()
    {
        return platModel.GetComponent<PlatformController>();
    }
}
