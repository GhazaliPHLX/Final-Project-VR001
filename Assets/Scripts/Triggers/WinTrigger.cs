using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour, IColliderTrigger
{
    public GameObject YouWinPanel;

    private void Start()
    {
        YouWinPanel.SetActive(false);
    }
    public void ColliderTrigger()
    {
        YouWinPanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
}
