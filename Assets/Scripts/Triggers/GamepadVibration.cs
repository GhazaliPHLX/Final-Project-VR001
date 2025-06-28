using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadVibrationManager : MonoBehaviour
{
    public static GamepadVibrationManager Instance;

    private Gamepad gamepad;
    private float leftMotor = 0f;
    private float rightMotor = 0f;

    public float fadeSpeed = 1f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        gamepad = Gamepad.current;
    }

    public void SetVibration(float leftPower, float rightPower)
    {
        // Ambil nilai tertinggi agar jika dua sumber nabrak bareng tetap maksimal
        leftMotor = Mathf.Max(leftMotor, leftPower);
        rightMotor = Mathf.Max(rightMotor, rightPower);
    }

    private void Update()
    {
        if (gamepad == null) return;

        gamepad.SetMotorSpeeds(leftMotor, rightMotor);

        // Fade out secara perlahan
        leftMotor = Mathf.MoveTowards(leftMotor, 0f, Time.deltaTime * fadeSpeed);
        rightMotor = Mathf.MoveTowards(rightMotor, 0f, Time.deltaTime * fadeSpeed);
    }

    private void OnDisable()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0f, 0f);
    }
}
