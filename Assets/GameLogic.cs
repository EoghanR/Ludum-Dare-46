using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    AsteroidSpawner asteroidSpawner;

    bool gameStarted = false;

    void Start()
    {
        asteroidSpawner = GameObject.Find("World").GetComponent<AsteroidSpawner>();
        asteroidSpawner.enabled = false;
    }

    void Update()
    {
        // replace with
        // click start button to start game
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            asteroidSpawner.enabled = true;
        }
    }
}
