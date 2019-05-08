using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    Vector3 targetPosition;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
    }

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            SetTargetPosition = hit.point;
            this.transform.LookAt(targetPosition);
        }
    }
}