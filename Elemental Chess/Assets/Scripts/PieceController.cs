using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    // [SerializeField][Range(1,20)]
    private float speed = 2;
    public bool turnEnded = false;
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
        //if (Input.GetMouseButtonDown(0) && piece.Selectable)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        if (hit.transform != null && hit.transform.gameObject == gameObject)
        //        {
        //            Rigidbody rb;
        //            if (rb = hit.transform.GetComponent<Rigidbody>())
        //            {
        //                isSelected = true;
        //                color.a = 0.5f;
        //                GetComponent<Renderer>().material.color = color;
        //                SendMessageUpwards("SelectPiece", piece);
        //            }
        //        }
        //    }
        //}

        //if (Input.GetMouseButtonDown(1) && isSelected)
        //{
        //    isSelected = false;
        //    color.a = 1;
        //    GetComponent<Renderer>().material.color = color;
        //    SendMessageUpwards("DeselectPiece", piece);
        //}
        
        if (isMoving)
            Move();
    }

    public void SetTargetPosition(Vector3 target)
    {
         targetPosition = target;

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
            turnEnded = true;
            color.a = 1;
            material.color = color;
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;
            rigidBody.detectCollisions = false;
        }
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (piece.Dead && collision.relativeVelocity.magnitude > 0.1)
    //    {
    //        rigidbody.AddForce(rigidbody.transform.up * 20, ForceMode.Impulse);
    //        Debug.Log(collision.relativeVelocity.magnitude);
    //    }
    //    //foreach (ContactPoint contact in collision.contacts)
    //    //{
    //    //    Debug.DrawRay(contact.point, contact.normal, Color.white);
    //    //}
    //}

}