using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Sprite[] sprites;
    private int index;

    public float maxTorque;
    public float maxThrust;

    public Rigidbody2D rb;

    public int asteroidSize; // Large = 2, Small = 1
    public GameObject asteroidSmall;

    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddTorque(torque);

        index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void FixedUpdate()
    {
        // point thrust to center of screen
        ApplyGravity();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet" || other.gameObject.tag == "shield")
        {
            Split();
            FindObjectOfType<AudioManager>().Play("AsteroidExplosion");
        }
}

    private void Split()
    {
        if (asteroidSize == 2)
        {
            Vector2 direction = Vector2.zero - rb.position;
            direction.Normalize();

            Vector2 thrust = new Vector2(direction.x, direction.y);
            Vector2 perpendicularThrust = Vector2.Perpendicular(thrust * (maxThrust));

            GameObject asteroidSmall1 = Instantiate(asteroidSmall, transform.position, transform.rotation);
            GameObject asteroidSmall2 = Instantiate(asteroidSmall, transform.position, transform.rotation);

            asteroidSmall1.GetComponent<Rigidbody2D>().AddForce(perpendicularThrust);
            asteroidSmall2.GetComponent<Rigidbody2D>().AddForce(-perpendicularThrust);
        }

        Destroy(gameObject);
    }

    private void ApplyGravity()
    {
        Vector2 direction = Vector2.zero - rb.position;

        float forceMagnitude = 200 * ((rb.mass * 10) / Mathf.Pow(direction.magnitude, 2));
        float forceMagnitudeClamped = Mathf.Clamp(forceMagnitude, 0, 2.5f);
        Vector2 force = forceMagnitudeClamped * direction.normalized;

        rb.AddForce(force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 1.0f);
    }
}
