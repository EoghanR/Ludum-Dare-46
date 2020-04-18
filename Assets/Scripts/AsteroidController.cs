using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Sprite[] sprites;
    private int index;

    private Vector3 euler;

    private Rigidbody2D rb;

    public float speed;

    public int asteroidSize; // Large = 3, Medium = 2, Small = 1
    public GameObject asteroidSmall;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];

        euler = transform.eulerAngles;
        euler.z = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateAsteroid();
        MoveToCenter();
    }

    private void RotateAsteroid()
    {
        transform.eulerAngles += euler;
    }

    private void MoveToCenter()
    {
        Vector2 target = Vector2.zero; // center of the screen
        Vector2 newPos = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.position = newPos;
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
            // Spawn 2 small asteroids in slightly different positions
            float range = -0.15f;

            //float distance1 = Random.Range(-range, range);
            //float distance2 = Random.Range(-range, range);

            float distance1 = range;
            float distance2 = -range;

            Vector2 newPos1 = new Vector2(transform.position.x + distance1, transform.position.y + distance1);
            Vector2 newPos2 = new Vector2(transform.position.x + distance2, transform.position.y + distance2);

            Instantiate(asteroidSmall, newPos1, transform.rotation);
            Instantiate(asteroidSmall, newPos2, transform.rotation);
        }
        Destroy(gameObject);
    }
}
