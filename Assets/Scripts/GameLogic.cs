using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameLogic : MonoBehaviour
{
    AsteroidSpawner asteroidSpawner;

    Text MainText1;
    Text MainText2;
    Text HighScoreText;
    Text GameOverText;

    private static bool introRan = false;

    public enum State { Intro, Running, Dead };

    State state;

    void Start()
    {
        MainText1 = GameObject.Find("MainText1").GetComponent<Text>();
        MainText2 = GameObject.Find("MainText2").GetComponent<Text>();
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
        GameOverText = GameObject.Find("GameOverText").GetComponent<Text>();

        HighScoreText.enabled = false;
        GameOverText.gameObject.SetActive(false);

        asteroidSpawner = GameObject.Find("World").GetComponent<AsteroidSpawner>();
        asteroidSpawner.enabled = false;
        SetState(State.Intro);

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
            SetState(State.Running);
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
                    SetState(State.Running);
                }
                break;
            case State.Running:

                // hide instructions & start game
                DisableInstructions();
                asteroidSpawner.enabled = true;

                break;
            case State.Dead:
                ShowGameOver();
                break;
        }
    }

    public void SetState(State s)
    {
        state = s;
    }

    public void DisableInstructions()
    {
        MainText1.gameObject.SetActive(false);
        MainText2.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        HighScoreText.enabled = true;
        GameOverText.gameObject.SetActive(true);
    }

    public State getCurrentState()
    {
        return state;
    }
}
