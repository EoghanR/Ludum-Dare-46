using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShieldRotation : MonoBehaviour
{

    float rotationSpeed = 5f;

    Vector3 mousePosition;
    Vector3 objectPosition;

    void Update()
    {
        mousePosition = Input.mousePosition;

        objectPosition = Camera.main.WorldToScreenPoint (transform.position);
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
