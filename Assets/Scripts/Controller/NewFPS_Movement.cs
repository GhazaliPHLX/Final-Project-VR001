using UnityEngine;
using UnityEngine.InputSystem;

public class NewFPS_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;

    [Header("Model Rotation")]
    public Transform modelTransform; 
    public float rotationSpeed = 10f;

    [Header("Camera")]
    public Transform cameraTransform;

    public Transform orientation;

    private Vector2 inputVector;
    private Vector3 moveDirection;

    private Rigidbody rb;

    [Header("Input System")]
    public InputActionReference moveInput;

    public bool IsMoving => inputVector.magnitude > 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        moveInput.action.Enable();
    }

    private void Update()
    {
        inputVector = moveInput.action.ReadValue<Vector2>();

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        orientation.forward = camForward;
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

       
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
