using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    [Range(1, 10)]
    private float jumpVelocity;
    
    [SerializeField]
    [Range(1, 10)]
    private float moveVelocity;
    [SerializeField]
    private int maxJumps;

    private int jumpCount = 0;

    private Rigidbody2D rb;
    private Vector3 lastDirectionMovement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleDash();

    }

    private void HandleDash()
    {
        //TO DO: it has to change but I don't know how to configure for multiple Joystick
        if (Input.GetKeyDown(KeyCode.H))
        {
            float dashDistance =2f;
            transform.position += lastDirectionMovement * dashDistance;
            //To Do: dash animation
        }
    }

    private void HandleMovement()
    {
   if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpCount--;
            Debug.Log("jumpcount: "+jumpCount);
        }

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
            lastDirectionMovement= new Vector3(1f,0f).normalized;
        } else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            rb.velocity = new Vector2(-moveVelocity, rb.velocity.y);
            lastDirectionMovement= new Vector3(-1f,0f).normalized;
        }
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            Debug.Log("jumpcount: "+jumpCount);
            jumpCount = maxJumps;
        }
        
    }

    void OnTriggerEnter2D (Collider2D Col) {
        if (Col.gameObject.tag == "Small Ledge" )
        {
            //Physics2D.IgnoreCollision(Col, GetComponent<Collider2D>());
            Debug.Log("hit");
            Debug.Log("jumpcount: "+jumpCount);
            jumpCount ++;
        }
    }

}
