using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAudioPlayer : MonoBehaviour, IColliding
{
    private AudioSource audioDanger;
    private float lastTriggeredTime;
    private float gracePeriod = 0.05f; // waktu tunggu kecil (opsional, biar lebih halus)

    private void Start()
    {
        audioDanger = GetComponent<AudioSource>();
        audioDanger.loop = true;
        audioDanger.playOnAwake = false;
    }

    public void Trigger()
    {
        lastTriggeredTime = Time.time;

        if (!audioDanger.isPlaying)
        {
            audioDanger.Play();
        }
    }

    private void Update()
    {
        // Jika sudah lewat frame tanpa dipanggil Trigger lagi
        if (Time.time - lastTriggeredTime > gracePeriod)
        {
            if (audioDanger.isPlaying)
            {
                audioDanger.Stop();
            }
        }
    }
}
