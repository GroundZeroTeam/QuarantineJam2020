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

    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "ground")
        {
            jumpCount = maxJumps;
        }
    }

}
