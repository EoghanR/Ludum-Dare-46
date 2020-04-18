using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShieldRotation : MonoBehaviour
{

    Vector3 mousePosition;
    Vector3 objectPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

        objectPosition = Camera.main.WorldToScreenPoint (transform.position);
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
