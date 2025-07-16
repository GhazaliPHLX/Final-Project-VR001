using UnityEngine;

public class GhostTriggerZone : MonoBehaviour
{
    public enum ZoneType { Outer, Inner }
    public ZoneType zoneType;

    public GhostStateManager ghost;
    public GameObject uiThinRed;
    public GameObject uiThickRed;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        switch (zoneType)
        {
            case ZoneType.Outer:
                uiThinRed.SetActive(true);
                uiThickRed.SetActive(false);
                ghost.SetState(ghost.chaseState);
                break;

            case ZoneType.Inner:
                uiThinRed.SetActive(false);
                uiThickRed.SetActive(true);
                ghost.SetState(ghost.chaseState); // tetap chasing
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Jika player keluar dari zone terakhir (baik outer maupun inner),
        // ghost masuk state bingung (confused), yang nanti auto balik ke patrol
        uiThinRed.SetActive(false);
        uiThickRed.SetActive(false);
        ghost.SetState(ghost.confusedState);
    }
}
