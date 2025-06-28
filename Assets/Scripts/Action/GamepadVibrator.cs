using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadVibrationHandler : MonoBehaviour
{
    private Gamepad gamepad;
    private WallProximityDetector detector;

    void Start()
    {
        gamepad = Gamepad.current;
        detector = GetComponent<WallProximityDetector>();

        if (detector == null)
        {
            Debug.LogWarning("WallProximityDetector tidak ditemukan di GameObject ini.");
        }
    }

    void Update()
    {
        if (gamepad == null || detector == null) return;

        gamepad.SetMotorSpeeds(detector.leftStrength, detector.rightStrength);
    }

    void OnDisable()
    {
        gamepad?.SetMotorSpeeds(0f, 0f);
    }
}
