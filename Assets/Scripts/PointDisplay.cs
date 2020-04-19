using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour
{
    Text pointsTotal;
    PointCounter pointCounter;

    void Start()
    {
        pointCounter = GameObject.Find("World").GetComponent<PointCounter>();
        pointsTotal = GameObject.Find("PointsText").GetComponent<Text>();
    }

    void Update()
    {
        int points = pointCounter.getPoints();
        pointsTotal.text = "Points: " + points;
    }
}
