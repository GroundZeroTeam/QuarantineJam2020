using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private float destroyAfterSeconds = 5.0f;

    [SerializeField]
    private Vector2 speed = new Vector2(5, 5);

    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        direction = new Vector2(transform.rotation.x * speed.x, transform.rotation.y * speed.y);

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
