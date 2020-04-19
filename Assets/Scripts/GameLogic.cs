using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    AsteroidSpawner asteroidSpawner;

    private static bool introRan = false;

    enum State { Intro, Running, Dead };

    State state;

    void Start()
    {
        asteroidSpawner = GameObject.Find("World").GetComponent<AsteroidSpawner>();
        asteroidSpawner.enabled = false;
        state = State.Intro;

        if (introRan)
        {
            DisableInstructions();
        }
    }

    void Update()
    {

        CheckState();

        // replace with
        // click start button to start game
        if (Input.GetMouseButtonDown(0))
        {
            state = State.Running;
            introRan = true;
        }

        // reload scene if R button is pressed
        if (Input.GetKey("r"))
        {
            ReloadCurrentScene();
        }
    }

    public void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void CheckState()
    {
        switch (state)
        {
            case State.Intro:
                if (introRan)
                {
                    state = State.Running;
                }
                break;
            case State.Running:

                // hide instructions & start game
                DisableInstructions();
                asteroidSpawner.enabled = true;

                break;
            case State.Dead:
                // reload current scene
                ReloadCurrentScene();
                break;
        }
    }

    public void DisableInstructions()
    {
        GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(4).gameObject.SetActive(false);
    }
}
