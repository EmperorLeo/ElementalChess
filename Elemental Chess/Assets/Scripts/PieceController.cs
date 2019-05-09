using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    // [SerializeField][Range(1,20)]
    private float speed = 2;
    Rigidbody rigidbody;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private bool isMoving;
    private bool isSelected;
    Material material;
    Color originalMaterialColor;


    const int RIGHT_MOUSE = 1;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalMaterialColor = material.color;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
        targetPosition = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(RIGHT_MOUSE))
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

    void ChangeColor()
    {
        material.color = Color.red;
    }

    void Move()
    {
        // transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
          //  isSelected = false;
            material.color = originalMaterialColor;
         
        }
    }

}