using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    
    [Header("Ground Movement")] public float moveSpeed = 100f;
    public float groundDrag = 5f;

    [Header("Camera")]
    private Transform cameraTransform;
    
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    [SerializeField] Rigidbody rb;

    [SerializeField] private GameObject leftWheel;
    [SerializeField] private GameObject rightWheel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!cameraTransform)
        {
            cameraTransform = Camera.main.transform;
        }
    }


    private void Update()
    {
        MyInput();
        SpeedControl();
        RotateWheels();
        rb.linearDamping = groundDrag;
            
        if (verticalInput < 0.1f && horizontalInput < 0.1f)
        {
            rb.linearDamping = 10;
        }
        SetPlayerRotation();
    }

    private void SetPlayerRotation()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        
    }

    private void RotateWheels()
    {
        if (!Mathf.Approximately(verticalInput, 0f) || !Mathf.Approximately(horizontalInput, 0f))
        {
            float rotationSpeed = moveSpeed * Time.deltaTime * 50f;
            leftWheel.transform.Rotate(new Vector3(rotationSpeed, 0f, 0f));
            rightWheel.transform.Rotate(new Vector3(rotationSpeed, 0f, 0f));
        }
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
        
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer()
    {
        // calculate movement direction
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

// Flatten the vectors (remove vertical tilt)
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        moveDirection = camForward * verticalInput + camRight * horizontalInput;

        rb.AddForce(moveSpeed * 10f * moveDirection.normalized, ForceMode.Force);
        
    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
    
    
}