using UnityEngine;

public class WallVibrationResponder : MonoBehaviour, IColliding
{
    [Range(0f, 1f)] public float leftPower = 1f;
    [Range(0f, 1f)] public float rightPower = 0.8f;

    public void Trigger()
    {
        if (GamepadVibrationManager.Instance != null)
        {
            GamepadVibrationManager.Instance.SetVibration(leftPower, rightPower);
        }
    }
}
