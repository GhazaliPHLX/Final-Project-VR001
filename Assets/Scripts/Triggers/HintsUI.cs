using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsUI : MonoBehaviour, IColliderTrigger, IColliderExit
{
    [Header("UI Buttons")]
    public List<GameObject> interactButtons = new List<GameObject>();

    [Header("Audio")]
    private AudioSource hint;
    public List<GameObject> Nexthints;
    public List<GameObject> branchHints;

    private void Start()
    {
        hint = GetComponent<AudioSource>();

        foreach (GameObject button in interactButtons)
        {
            if (button != null)
                button.SetActive(false);
        }
    }

    public void ColliderTrigger()
    {
        hint.Stop();

        foreach (GameObject go in Nexthints)
        {
            AudioSource source = go.GetComponent<AudioSource>();
            if (source != null)
            {
                foreach (GameObject button in interactButtons)
                    button?.SetActive(true);

                source.Play();
            }
        }

        foreach (GameObject go in branchHints)
        {
            AudioSource source = go.GetComponent<AudioSource>();
            if (source != null)
                source.Stop();
        }
    }

    public void ColliderExit()
    {
        foreach (GameObject button in interactButtons)
            button?.SetActive(false);
    }
}
