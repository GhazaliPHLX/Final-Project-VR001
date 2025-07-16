using UnityEngine;

public class GhostChaseState : IState
{
    private GhostStateManager ghost;

    public GhostChaseState(GhostStateManager g)
    {
        ghost = g;
    }

    public void OnEnter()
    {
        Debug.Log("Enter CHASE");
        ghost.ghostAnimator.SetBool("isChasing", true);
        ghost.ghostAnimator.SetBool("isPatrol", false);
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
        Debug.Log("Exit CHASE");
        ghost.ghostAnimator.SetBool("isChasing", false);
    }
}
