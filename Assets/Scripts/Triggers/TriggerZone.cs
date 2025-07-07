using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject hint;
    private AudioSource hintAudio;

    private void Start()
    {
        hintAudio = hint.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hintAudio != null)
        {
            Debug.Log("Player Masuk Trigger Zone");
            hintAudio.Play();
        }
        else
        {
            Debug.Log("Audio Kosong");
        }
    }
}
