using UnityEngine;

public class GhostConfusedState : IState
{
    private GhostStateManager ghost;
    private float timer;
    private float waitTime = 3f;

    public GhostConfusedState(GhostStateManager ghost)
    {
        this.ghost = ghost;
    }

    public void OnEnter()
    {
        ghost.ghostAnimator.SetBool("isChasing", false);
        ghost.ghostAnimator.SetBool("isPatrol", false);
        ghost.agent.ResetPath();
        timer = 0f;

        ghost.ghostAudio.StopPatrol();
        ghost.ghostAudio.StopChase();
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ghost.SetState(ghost.patrolState);
        }
    }

    public void OnExit() { }
}
