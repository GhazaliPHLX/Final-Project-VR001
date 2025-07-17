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

        // Set target player saat masuk trigger
        ghost.player = other.transform;

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
                ghost.SetState(ghost.chaseState);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Hide"))
        {
            uiThinRed.SetActive(false);
            uiThickRed.SetActive(false);

            // Hentikan pengejaran
            ghost.player = null;
            ghost.agent.ResetPath();
            ghost.SetState(ghost.confusedState);
        }
    }
}
