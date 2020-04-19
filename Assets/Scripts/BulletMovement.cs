﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D projectile;
    PointCounter pointCounter;
    void Start()
    {
        pointCounter = GameObject.Find("World").GetComponent<PointCounter>();
        projectile.velocity = transform.right * speed;
    }

    void Update()
    {
        if(transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        pointCounter.increasePoints(collision.gameObject.tag);
    }
}