using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShieldRotation : MonoBehaviour
{

    bool MouseInput = true;

    float rotationSpeed = 5f;

    float keyboardRotSpeed =  150f;

    Vector3 mousePosition;
    Vector3 objectPosition;

    void Update()
    {
        mousePosition = Input.mousePosition;

        if (Input.GetButtonDown("Fire1")){
            MouseInput = true;
        }else if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)){
            MouseInput = false;
        }

        if (MouseInput){
            objectPosition = Camera.main.WorldToScreenPoint (transform.position);
            mousePosition.x -= objectPosition.x;
            mousePosition.y -= objectPosition.y;

            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }else{
            if (Input.GetKey(KeyCode.LeftArrow)){
                transform.Rotate(Vector3.forward * keyboardRotSpeed * Time.deltaTime);
            }else if (Input.GetKey(KeyCode.RightArrow)){
                transform.Rotate(Vector3.forward * -keyboardRotSpeed * Time.deltaTime);
            }
        }
    }
}
