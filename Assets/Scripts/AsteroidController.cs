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

    void Start()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            Split();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Split();
        }
}

    private void Split()
    {
        if (asteroidSize == 2)
        {
            Instantiate(asteroidSmall, transform.position, transform.rotation);
            Instantiate(asteroidSmall, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
