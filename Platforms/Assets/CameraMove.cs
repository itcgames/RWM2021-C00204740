using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject player;
    Vector3 position = new Vector3(0, 0, -10);
    // Update is called once per frame
    void Update()
    {
        position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        gameObject.transform.position = position;
    }
}
