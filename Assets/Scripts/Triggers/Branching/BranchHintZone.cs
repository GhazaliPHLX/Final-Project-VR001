using UnityEngine;

public class BranchHintZone : MonoBehaviour
{
    public GameObject hintObject;       // GameObject hint yang punya AudioSource
    private AudioSource hintAudio;      // Diambil otomatis dari hintObject

    public BranchGroup group;

    private bool playerInside = false;

    void Start()
    {
        if (hintObject != null)
        {
            hintAudio = hintObject.GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            group.OnBranchEntered(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    public void SetHintActive(bool active)
    {
        StopAllCoroutines();
        if (hintAudio != null)
            StartCoroutine(FadeAudio(active));
    }

    private System.Collections.IEnumerator FadeAudio(bool fadeIn)
    {
        float duration = 1f;
        float startVol = hintAudio.volume;
        float endVol = fadeIn ? 1f : 0f;
        float time = 0f;

        if (fadeIn && !hintAudio.isPlaying)
            hintAudio.Play();

        while (time < duration)
        {
            time += Time.deltaTime;
            if (hintAudio != null)
                hintAudio.volume = Mathf.Lerp(startVol, endVol, time / duration);
            yield return null;
        }

        if (hintAudio != null)
        {
            hintAudio.volume = endVol;
            if (!fadeIn) hintAudio.Stop();
        }
    }
}
