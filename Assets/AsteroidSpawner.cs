using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float radius;
    public int numAsteroids = 1;

    Vector3 center;

    public GameObject asteroid;

    void Start()
    {
        center = transform.position;
        for (int i = 0; i < numAsteroids; i++)
        {
            Vector2 position = SpawnCircle(center, radius);
            Quaternion rotation = Quaternion.identity;
            Instantiate(asteroid, position, rotation);
        }
    }

    // Spawn asteroid in random position around center of screen
    Vector2 SpawnCircle(Vector3 center, float radius)
    {
        float angle = Random.value * 360;
        Vector2 position;
        position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return position;
    }
}
