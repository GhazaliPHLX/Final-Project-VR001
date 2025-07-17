using UnityEngine;

public class GhostPatrolState : IState
{
    private GhostStateManager ghost;
    private int currentWaypoint = 0;
    private GhostAudio ghostAudio;

    public GhostPatrolState(GhostStateManager g)
    {
        ghost = g;
        ghostAudio = ghost.GetComponent<GhostAudio>();

    }

    public void OnEnter()
    {
        Debug.Log("Enter PATROL");
        ghost.ghostAnimator.SetBool("isChasing", false);
        ghost.ghostAnimator.SetBool("isPatrol", true);
        ghostAudio.PlayPatrol();
        MoveToNextPoint();
    }

    public void OnUpdate()
    {
        if (!ghost.agent.pathPending && ghost.agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }

    public void OnExit()
    {
        Debug.Log("Exit PATROL");
        ghost.ghostAnimator.SetBool("isPatrol", false);
    }

    private void MoveToNextPoint()
    {
        if (ghost.patrolPoints == null || ghost.patrolPoints.Count == 0) return;

        ghost.agent.SetDestination(ghost.patrolPoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % ghost.patrolPoints.Count;
    }
}
