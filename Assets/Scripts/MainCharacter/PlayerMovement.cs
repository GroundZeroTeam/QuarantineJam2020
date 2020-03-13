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
    private int maxJumps = 1;

    private int jumpCount = 0;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpCount--;
        }

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        } else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            rb.velocity = new Vector2(-moveVelocity, rb.velocity.y);
        }

    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            jumpCount = maxJumps;
        }
    }

}
