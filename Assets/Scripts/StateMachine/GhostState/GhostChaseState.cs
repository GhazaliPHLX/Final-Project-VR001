using UnityEngine;

public class GhostChaseState : IState
{
    private GhostStateManager ghost;
    private GhostAudio ghostAudio;

    public GhostChaseState(GhostStateManager g)
    {
        ghost = g;
        ghostAudio = ghost.GetComponent<GhostAudio>();
    }

    public void OnEnter()
    {
        Debug.Log("Enter CHASE");

        // Set animasi
        ghost.ghostAnimator.SetBool("isChasing", true);
        ghost.ghostAnimator.SetBool("isPatrol", false);

        // Play audio
        ghostAudio.PlayChase();
    }

    public void OnUpdate()
    {

        if (ghost.player != null)
        {
            // Hanya kejar jika tag masih "Player"
            if (ghost.player.CompareTag("Player"))
            {
                if (ghost.agent.enabled && ghost.agent.isOnNavMesh)
                {
                    ghost.agent.SetDestination(ghost.player.position);
                }
            }
            else
            {
                // Player tidak valid, keluar dari chase state
                ghost.SetState(ghost.confusedState);
            }
        }
    }

    public void OnExit()
    {
        Debug.Log("Exit CHASE");

        // Matikan animasi
        ghost.ghostAnimator.SetBool("isChasing", false);

        // Stop audio
        ghostAudio.StopChase();
    }
}
