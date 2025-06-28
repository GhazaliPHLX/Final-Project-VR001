using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SteamAudioOcclusionEnabler : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Spatialize harus aktif
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;

        // Kirim instruksi ke Steam Audio Spatializer untuk aktifkan occlusion
        // Parameter index 0 = occlusion (dari Steam Audio internal)
        // Nilai 1.0f = occlusion aktif
        audioSource.SetSpatializerFloat(0, 1.0f);
    }
}
