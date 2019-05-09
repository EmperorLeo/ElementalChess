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
    Color color;
    BasePiece piece;

    const int RIGHT_MOUSE = 1;

    void Start()
    {
        piece = GetComponent<BasePiece>();
        material = GetComponent<Renderer>().material;
        color = material.color;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
        targetPosition = transform.position;
        isMoving = false;
    }

    void Update()
    {        
        if (Input.GetMouseButtonDown(0) && piece.Selectable)
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
                        SendMessageUpwards("SelectPiece", piece);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            isSelected = false;
            color.a = 1;
            GetComponent<Renderer>().material.color = color;
            SendMessageUpwards("DeselectPiece", piece);
        }
        
        if (isMoving)
            Move();
    }

    public void SetTargetPosition()
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
            isSelected = false;
            color.a = 1;
            material.color = color;
        }
    }

    public bool IsSelected()
    {
        return isSelected;
    }

}