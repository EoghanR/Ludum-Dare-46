using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotationConstant : MonoBehaviour
{

    public float rotationSpeed;

    void Update()
    {
        // Will rotate "rotationSpeed" coords every second in the anti-clockwise direction.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
