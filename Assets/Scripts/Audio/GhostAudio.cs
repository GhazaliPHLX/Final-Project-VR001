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
        patrolSource.maxDistance = 5.0f;
        patrolSource.minDistance = 1.0f;
        patrolSource.outputAudioMixerGroup = ghostMixerGroup;
        patrolSource.dopplerLevel = 1.0f;

        chaseSource.clip = chaseClip;
        chaseSource.loop = true;
        chaseSource.spatialBlend = 1.0f;
        chaseSource.maxDistance = 5.0f;
        chaseSource.minDistance = 1.0f;
        chaseSource.outputAudioMixerGroup = ghostMixerGroup;
        chaseSource.dopplerLevel = 1.0f;

    }

    public void PlayPatrol()
    {
        if (!patrolSource.isPlaying)
            patrolSource.Play();
        Debug.Log("PatrolAudioPlay");
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
        Debug.Log("ChaseAudioPlay");

    }

    public void StopChase()
    {
        if (chaseSource.isPlaying)
            chaseSource.Stop();
    }
}
