using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStopper : MonoBehaviour, IColliding
{
    private AudioSource m_Source;
    public AudioSource nextHint;

    private void Start()
    {
        m_Source = GetComponent<AudioSource>();
        if (m_Source == null)
        {
            Debug.Log("AudioSource Kosong");
        }
    }
    public void Trigger()
    {
        m_Source.Stop();
        nextHint.Play();
    }

   
}
