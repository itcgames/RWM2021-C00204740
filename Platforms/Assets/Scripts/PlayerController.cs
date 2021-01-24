using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;                
    private Rigidbody2D rb;
    public Vector2 jumpHeight;
    public float jumpSpeed;
    private BoxCollider2D boxCollider;
    [SerializeField]private LayerMask platLayer;
    void Start()
    {
        playerSpeed = 3.0f;
        jumpSpeed = 5.0f;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
        rb.freezeRotation = true;
    }

   
    void Update()
    {
        //very basic player movement for test
        if(isGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
        Move();
    }
    private bool isGrounded()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0.0f, Vector2.down * 0.1f, platLayer);
        return rayHit;
        
    }
    private void Move()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
        }
        else
        {
            if(Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
}