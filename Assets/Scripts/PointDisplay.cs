using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour
{
    Text pointsTotal;
    Text highScore;
    PointCounter pointCounter;

    GameLogic gameLogic;

    void Start()
    {
        pointCounter = GameObject.Find("World").GetComponent<PointCounter>();
        pointsTotal = GameObject.Find("PointsText").GetComponent<Text>();
        highScore = GameObject.Find("HighScoreText").GetComponent<Text>();
        gameLogic = GameObject.Find("World").GetComponent<GameLogic>();
    }

    void Update()
    {
        
        if (gameLogic.getCurrentState() != GameLogic.State.Dead)
        {
            int points = pointCounter.getPoints();
            pointsTotal.text = "Points: " + points;
            highScore.text = "Your score was " + points;
        }
    }
}
