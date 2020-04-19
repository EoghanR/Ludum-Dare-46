using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float radius;
    public float spawnTime;
    public float spawnDelay;

    Vector3 center;

    GameLogic gameLogic = new GameLogic();

    public GameObject asteroid;

    private void Start()
    {
        center = transform.position;

        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        if (gameLogic.getCurrentState() != GameLogic.State.Dead)
        {
            Vector2 position = SpawnCircle(center, radius);
            Quaternion rotation = Quaternion.identity;
            Instantiate(asteroid, position, rotation);
        } else
        {
            CancelInvoke("Spawn");
        }
    }

    // Spawn asteroid in random position around center of screen
    Vector2 SpawnCircle(Vector3 center, float radius)
    {
        float angle = Random.value * 360;
        Vector2 position;
        position.x = center.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return position;
    }

}
