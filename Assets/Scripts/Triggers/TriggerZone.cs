using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject hint;
    private AudioSource hintAudio;
    private Boolean isTriggered;

    public List<GameObject> prevHints;


    private void Start()
    {
        hintAudio = hint.GetComponent<AudioSource>();
        isTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hintAudio != null && !isTriggered)
        {
            Debug.Log("Player Masuk Trigger Zone");
            hintAudio.Play();
            isTriggered = true;
        }
        else
        {
            Debug.Log("Audio Kosong");
        }

        foreach (GameObject go in prevHints)
        {
            AudioSource source = go.GetComponent<AudioSource>();
            if (source != null)
            {
                source.Pause();
            }
            else
            {
                Debug.LogWarning("GameObject " + go.name + " tidak memiliki AudioSource!");
            }
        }
    }
}
