using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMovement : MonoBehaviour
{
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {

    }
    bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
    bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
    }
}