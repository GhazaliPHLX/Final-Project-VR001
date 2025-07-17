using UnityEngine;

public class GhostChaseState : IState
{
    private GhostStateManager ghost;

    public GhostChaseState(GhostStateManager ghost)
    {
        this.ghost = ghost;
    }

    public void OnEnter()
    {
        ghost.ghostAnimator.SetBool("isChasing", true);
        ghost.ghostAnimator.SetBool("isPatrol", false);

        ghost.ghostAudio.StopPatrol();
        ghost.ghostAudio.PlayChase();
    }

    public void OnUpdate()
    {
        if (ghost.player != null)
        {
            ghost.agent.SetDestination(ghost.player.position);
        }
    }

    public void OnExit()
    {
        ghost.ghostAnimator.SetBool("isChasing", false);
        ghost.ghostAudio.StopChase();
    }
}