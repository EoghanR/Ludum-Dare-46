using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D projectile;
    void Start()
    {
        projectile.velocity = transform.right * speed;
    }

    void Update()
    {
        if(transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        Debug.Log(hitObject.name);
        Destroy(gameObject);
    }
}
