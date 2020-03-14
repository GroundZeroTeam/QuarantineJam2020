using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    [Range(1, 10)]
    private float moveVelocity;

    [SerializeField]
    [Range(1, 10)]
    private float destroyAfterSeconds = 5.0f;

    private Transform centerPoint;

    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        centerPoint = GameObject.Find("Center Ground").transform;
    }

    private void Start()
    {
        if ((centerPoint.position.x - transform.position.x) > 0.0f)
        {
            direction = new Vector2(moveVelocity, -5f);
        }
        else if ((centerPoint.position.x - transform.position.x) < 0.0f)
        {
            direction = new Vector2(-moveVelocity, -5f);
        }

        StartCoroutine(WaitForDestroy());

    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction;

    }

    IEnumerator WaitForDestroy()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(destroyAfterSeconds);

        Destroy(gameObject);
    }
}
