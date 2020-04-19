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

    void Start()
    {
        pointCounter = GameObject.Find("World").GetComponent<PointCounter>();
        pointsTotal = GameObject.Find("PointsText").GetComponent<Text>();
        highScore = GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(7).GetComponent<Text>();

    }

    void Update()
    {
        int points = pointCounter.getPoints();
        pointsTotal.text = "Points: " + points;
        highScore.text = "Your score was " + points;
    }
}
