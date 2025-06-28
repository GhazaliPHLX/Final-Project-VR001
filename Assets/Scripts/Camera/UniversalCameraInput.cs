using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UniversalCameraInput : MonoBehaviour
{
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;

    public Transform orientation;

    private float xRotation;
    private float yRotation;

    public InputActionReference lookInput; // Drag dari InputActions: Player/Look

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookInput.action.Enable();
    }

    private void Update()
    {
        
        Vector2 gamepadInput = lookInput.action.ReadValue<Vector2>();

      
        Vector2 finalLook = (gamepadInput) * Time.deltaTime;

        yRotation += finalLook.x * sensitivityX;
        xRotation -= finalLook.y * sensitivityY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void OnDisable()
    {
        lookInput.action.Disable();
    }
}
