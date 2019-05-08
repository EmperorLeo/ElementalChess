using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    // [SerializeField][Range(1,20)]
    private float speed = 10;

    private Vector3 targetPosition;
    private bool isMoving;

    const int LEFT_MOUSE = 0;

    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(LEFT_MOUSE))
            SetTargetPosition();

        if (isMoving)
            Move();
    }

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        isMoving = true;
    }

    void Move()
    {
        Quaternion rot = GetComponent<Rigidbody>().rotation;
        rot[0] = 0; //null rotation X
        rot[2] = 0; //null rotation Z
        GetComponent<Rigidbody>().rotation = rot;

        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
            isMoving = false;

        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

}

/*
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion pieceRot;
    float rotSpeed = 5;
    float speed = 2;
    bool moving = false;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        if (moving)
            Move();
    }

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = hit.point;
            // this.transform.LookAt(targetPosition);
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                transform.position.y,
                targetPosition.z - transform.position.z);
            pieceRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            pieceRot, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,
                                                 targetPosition,
                                                 speed * Time.deltaTime);

        if (transform.position == targetPosition)
            moving = false;
    }
}*/