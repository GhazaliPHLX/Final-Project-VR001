using UnityEngine;

public class AmbienceTrigger : MonoBehaviour, IColliderTrigger
{
    public AudioClip ambienceClip;
    public float fadeDuration = 1f;

    public void ColliderTrigger()
    {
        AmbienceManager.Instance.ChangeAmbience(ambienceClip, fadeDuration);
    }
}
