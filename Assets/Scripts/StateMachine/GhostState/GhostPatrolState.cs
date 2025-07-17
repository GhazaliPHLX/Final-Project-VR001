using UnityEngine;

public class GhostPatrolState : IState
{
    private GhostStateManager ghost;

    public GhostPatrolState(GhostStateManager ghost)
    {
        this.ghost = ghost;
    }

    public void OnEnter()
    {
        ghost.ghostAnimator.SetBool("isChasing", false);
        ghost.ghostAnimator.SetBool("isPatrol", true);
        MoveToNextPoint();

        ghost.ghostAudio.StopChase();
        ghost.ghostAudio.PlayPatrol();
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
        ghost.ghostAnimator.SetBool("isPatrol", false);
    }

    private void MoveToNextPoint()
    {
        if (ghost.patrolPoints.Count == 0) return;

        ghost.agent.destination = ghost.patrolPoints[ghost.currentPatrolIndex].position;
        ghost.currentPatrolIndex = (ghost.currentPatrolIndex + 1) % ghost.patrolPoints.Count;
    }
}