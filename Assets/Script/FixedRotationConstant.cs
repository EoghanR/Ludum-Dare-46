using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotationConstant : MonoBehaviour
{

    public long rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Will rotate "rotationSpeed" coords every second in the anti-clockwise direction.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
