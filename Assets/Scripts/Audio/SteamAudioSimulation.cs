//  WebGL-Compatible Audio Simulation Script (Spatial + Occlusion + Reverb)

using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SmartAudioSource : MonoBehaviour
{
    public Transform listener; // Assign Player or Camera
    public LayerMask occlusionMask;
    public AudioMixer audioMixer; // Assign Mixer with exposed params
    public string lowpassParamName = "LowpassFreq";

    public float maxDistance = 30f;
    public float minDistance = 2f;
    public float occludedVolume = 0.2f;
    public float clearVolume = 1.0f;
    public float occlusionCheckRate = 0.1f;

    private AudioSource source;
    private float checkTimer;
    private bool isOccluded;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.spatialBlend = 1.0f;
        source.rolloffMode = AudioRolloffMode.Custom;
        source.maxDistance = maxDistance;
        source.minDistance = minDistance;
    }

    private void Update()
    {
        if (listener == null) return;

        checkTimer -= Time.deltaTime;
        if (checkTimer <= 0f)
        {
            checkTimer = occlusionCheckRate;

            Vector3 dir = (listener.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, listener.position);

            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, distance, occlusionMask))
            {
                if (!isOccluded)
                {
                    isOccluded = true;
                    ApplyOcclusion(true);
                }
            }
            else
            {
                if (isOccluded)
                {
                    isOccluded = false;
                    ApplyOcclusion(false);
                }
            }
        }
    }

    private void ApplyOcclusion(bool occluded)
    {
        float volume = occluded ? occludedVolume : clearVolume;
        float lowpass = occluded ? 600f : 22000f; // Hz

        source.volume = volume;
        if (audioMixer)
        {
            audioMixer.SetFloat(lowpassParamName, lowpass);
        }
    }
}
