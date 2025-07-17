using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtScript : MonoBehaviour, IColliding
{
    public GameManager GameManager;
    public GameObject YouDiedPanel;

    private void Start()
    {
        YouDiedPanel.SetActive(false);
    }

    public void Trigger()
    {
        YouDiedPanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;

    }

    
}
