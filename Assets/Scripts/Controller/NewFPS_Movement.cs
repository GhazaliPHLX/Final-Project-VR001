using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewFPS_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;

    public Transform orientation;

    private Vector2 inputVector;
    private Vector3 moveDirection;

    private Rigidbody rb;

    [Header("Input System")]
    public InputActionReference moveInput; // Drag dari InputActions: Player/Move

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Aktifkan action (penting agar bisa membaca input)
        moveInput.action.Enable();
    }

    private void Update()
    {
        // Baca input dari Input System
        inputVector = moveInput.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * inputVector.y + orientation.right * inputVector.x;

        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
        Vector3 velocityChange = targetVelocity - new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(new Vector3(velocityChange.x, 0, velocityChange.z), ForceMode.VelocityChange);
    }
}
