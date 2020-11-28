using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{




    private Rigidbody2D rb2D;
    float Movespeed = 5.0f;

    void FixedUpdate()
    {
        float xmove = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(xmove * Movespeed, rb2D.velocity.y);
    }
}