using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    // [SerializeField][Range(1,20)]
    private float speed = 2;
    Rigidbody rigidbody;
    private Vector3 targetPosition;
    private bool isMoving;
    private bool isSelected;
    Material material;
    Color color;


    const int LEFT_MOUSE = 0;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
        targetPosition = transform.position;
        isMoving = false;
        isSelected = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject == gameObject)
                {
                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        isSelected = true;
                        color.a = 0.5f;
                        GetComponent<Renderer>().material.color = color;
                    }
                }
            }
        }

        if (Input.GetMouseButton(LEFT_MOUSE) && isSelected)
         //  SetTargetPosition();

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
        // transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
            isSelected = false;
            color.a = 1;
            material.color = color;
         
        }

        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

    public bool IsSelected()
    {
        return isSelected;
    }

}