using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    [Header("Current Hint")]
    public AudioSource currentHint;

    [Header("Next Hints")]
    public List<AudioSource> nextHints;

    [Header("Branching Hints to Mute")]
    public List<AudioSource> branchHints;

    [Header("Fade Settings")]
    public float fadeOutTime = 1.5f;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        if (currentHint != null)
            StartCoroutine(FadeOut(currentHint));

        foreach (var next in nextHints)
        {
            if (!next.isPlaying) next.Play();
        }

        foreach (var branch in branchHints)
        {
            if (branch.isPlaying) StartCoroutine(FadeOut(branch));
        }
    }

    private IEnumerator FadeOut(AudioSource source)
    {
        float startVolume = source.volume;
        float t = 0;
        while (t < fadeOutTime)
        {
            source.volume = Mathf.Lerp(startVolume, 0, t / fadeOutTime);
            t += Time.deltaTime;
            yield return null;
        }
        source.Stop();
        source.volume = startVolume;
    }
}
