using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static int points = 0;

    public int getPoints()
    {
        return points;
    }

    public void increasePoints(string destroyedTarget)
    {
        if (destroyedTarget == "sba")
        {
            points += 50;
        }
        else if (destroyedTarget == "lba")
        {
            points += 100;
        }
    }
}
