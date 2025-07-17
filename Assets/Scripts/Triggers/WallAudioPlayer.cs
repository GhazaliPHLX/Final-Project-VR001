using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAudioPlayer : MonoBehaviour, IColliding
{
    private AudioSource audioDanger;
    private float lastTriggeredTime;
    private float gracePeriod = 0.05f;
    private Transform audioPoint;

    private void Start()
    {
        // Cari child bernama "AudioPoint"
        audioPoint = transform.Find("AudioPoint");

        if (audioPoint == null)
        {
            Debug.LogWarning($"AudioPoint tidak ditemukan di {gameObject.name}");
            return;
        }

        audioDanger = audioPoint.GetComponent<AudioSource>();

        if (audioDanger == null)
        {
            Debug.LogWarning($"AudioSource tidak ditemukan di AudioPoint child");
            return;
        }

        audioDanger.loop = true;
        audioDanger.playOnAwake = false;
        audioDanger.spatialBlend = 1f; // full 3D
    }

    public void Trigger()
    {
        lastTriggeredTime = Time.time;

        if (audioDanger == null || audioPoint == null) return;

        // Cari posisi player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        // Hitung arah relatif player terhadap tembok
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 offset = Vector3.zero;

        // Tentukan offset ke arah sisi tembok
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
            offset = new Vector3(Mathf.Sign(direction.x) * 0.45f, 0, 0); // kiri-kanan
        else
            offset = new Vector3(0, 0, Mathf.Sign(direction.z) * 0.45f); // depan-belakang

        // Pindahkan posisi AudioPoint relatif terhadap tembok
        audioPoint.localPosition = offset;

        if (!audioDanger.isPlaying)
        {
            audioDanger.Play();
        }
    }

    private void Update()
    {
        if (Time.time - lastTriggeredTime > gracePeriod)
        {
            if (audioDanger != null && audioDanger.isPlaying)
            {
                audioDanger.Stop();
            }
        }
    }
}
