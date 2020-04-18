using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    Vector3 euler;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        euler = transform.eulerAngles;
        euler.z = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += euler;

        MoveToCenter();
    }

    private void MoveToCenter()
    {
        Vector2 target = Vector2.zero; // center of the screen
        Vector2 newPos = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.position = newPos;
    }
}
