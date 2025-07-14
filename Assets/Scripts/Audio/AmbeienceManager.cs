using UnityEngine;
using System.Collections;

public class AmbienceManager : MonoBehaviour
{
    public static AmbienceManager Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AmbienceManager membutuhkan AudioSource di GameObject-nya.");
            }
            else
            {
                audioSource.loop = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void ChangeAmbience(AudioClip newClip, float fadeDuration)
    {
        StartCoroutine(FadeToNewClip(newClip, fadeDuration));
    }

    private IEnumerator FadeToNewClip(AudioClip newClip, float duration)
    {
        float startVolume = audioSource.volume;

        // Fade out
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.clip = newClip;
        audioSource.Play();
        Debug.Log(newClip.name + " Is Playing");

        // Fade in
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / duration);
            yield return null;
        }

        audioSource.volume = startVolume;
    }
}
