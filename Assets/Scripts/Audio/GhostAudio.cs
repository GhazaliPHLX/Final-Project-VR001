using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GhostAudio : MonoBehaviour
{
    public AudioClip patrolClip;
    public AudioClip chaseClip;
    public AudioMixerGroup ghostMixerGroup;

    private AudioSource patrolSource;
    private AudioSource chaseSource;

    private void Awake()
    {
        // Tambahkan dua AudioSource secara dinamis
        patrolSource = gameObject.AddComponent<AudioSource>();
        chaseSource = gameObject.AddComponent<AudioSource>();

        patrolSource.clip = patrolClip;
        patrolSource.loop = true;
        patrolSource.spatialBlend = 1.0f;
        patrolSource.maxDistance = 30.0f;
        patrolSource.minDistance = 1.0f;
        patrolSource.outputAudioMixerGroup = ghostMixerGroup;

        chaseSource.clip = chaseClip;
        chaseSource.loop = true;
        chaseSource.spatialBlend = 1.0f;
        chaseSource.maxDistance = 30.0f;
        chaseSource.minDistance = 1.0f;
        chaseSource.outputAudioMixerGroup = ghostMixerGroup;

    }

    public void PlayPatrol()
    {
        if (!patrolSource.isPlaying)
            patrolSource.Play();
    }

    public void StopPatrol()
    {
        if (patrolSource.isPlaying)
            patrolSource.Stop();
    }

    public void PlayChase()
    {
        if (!chaseSource.isPlaying)
            chaseSource.Play();
    }

    public void StopChase()
    {
        if (chaseSource.isPlaying)
            chaseSource.Stop();
    }
}
