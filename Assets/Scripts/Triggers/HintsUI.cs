using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsUI : MonoBehaviour, IColliderTrigger
{
    //public GameObject uiButton;
    private AudioSource hint;
    
    public List<GameObject> Nexthints;

    public List<GameObject> branchHints;


    private void Start()
    {
        hint = GetComponent<AudioSource>();


    }
    public void ColliderTrigger()
    {
        hint.Stop();

        foreach (GameObject go in Nexthints)
        {
            AudioSource source = go.GetComponent<AudioSource>();
            if (source != null)
            {
                source.Play();
            }
            else
            {
                Debug.LogWarning("GameObject " + go.name + " tidak memiliki AudioSource!");
            }
        }

        foreach (GameObject go in branchHints)
        {
            AudioSource source = go.GetComponent<AudioSource>();
            if (source != null)
            {
                source.Stop();
            }
            else
            {
                Debug.LogWarning("GameObject " + go.name + " tidak memiliki AudioSource!");
            }
        }

    }


}
