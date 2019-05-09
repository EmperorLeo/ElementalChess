using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public void Rotate()
    { 
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
