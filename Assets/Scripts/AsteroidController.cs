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

        // point thrust to center of screen
        Vector2 thrust = new Vector2(-transform.position.x * maxThrust, -transform.position.y * maxThrust);
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
        rb.AddTorque(torque);

        index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Split();
            FindObjectOfType<AudioManager>().Play("AsteroidExplosion");
        }
}

    private void Split()
    {
        if (asteroidSize == 2)
        {
            GameObject asteroidSmall1 = Instantiate(asteroidSmall, transform.position, transform.rotation);
            GameObject asteroidSmall2 = Instantiate(asteroidSmall, transform.position, transform.rotation);

            float modifier = 0.25f;
            float thrustX = Random.Range(-maxThrust * modifier, maxThrust * modifier);
            float thrustY = Random.Range(-maxThrust * modifier, maxThrust * modifier);
            Vector2 thrust = new Vector2(thrustX, thrustY);
            asteroidSmall1.GetComponent<Rigidbody2D>().AddForce(thrust);

            thrustX = Random.Range(-maxThrust * 0.5f, maxThrust * 0.5f);
            thrustY = Random.Range(-maxThrust * 0.5f, maxThrust * 0.5f);
            thrust = new Vector2(thrustX, thrustY);
            asteroidSmall2.GetComponent<Rigidbody2D>().AddForce(thrust);
        }

        Destroy(gameObject);
    }
}
