using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float torqueForce = 10f;   
    public float jumpForce = 10f;     
    public float airControlMultiplier = 0.2f; 
    public float maxAngularVelocity = 50f;
    public float rotationSpeed = 90.0f;

    private Rigidbody rb;
    private bool isGrounded;
    public Transform orientation;

    private Vector3 startLocation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;

        //helper
        orientation = new GameObject("Ball Orierntation").transform;
        orientation.position = transform.position;
        orientation.rotation = transform.rotation;

        //starting position
        startLocation = transform.position;
    }

    private void Update()
    {
        isGrounded = CheckGrounded();
        HandleRotation();
        ApplyTorque();
        HandleJump();

        if (Input.GetKey(KeyCode.R))
        {
            ResetPosition();
        }
    }
    public void ResetPosition()
    {
        this.transform.position = startLocation;
    }
    private void HandleRotation()
    {
        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q)) rotate = -1f;
        if (Input.GetKey(KeyCode.E)) rotate = 1f;

        if (rotate != 0)
        {
            orientation.Rotate(rotate * rotationSpeed * Time.deltaTime * Vector3.up);
        }

        orientation.position = transform.position;
    }

    private void ApplyTorque()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * -moveX + orientation.right * moveZ;
        moveDirection.y = 0; 
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            if (isGrounded)
            {
                rb.AddTorque(moveDirection * torqueForce, ForceMode.Acceleration);
            }
            else
            {
                rb.AddTorque(moveDirection * torqueForce * airControlMultiplier, ForceMode.Acceleration);

            }
        }
    }



    private void HandleJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool CheckGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.7f);
    }


}
