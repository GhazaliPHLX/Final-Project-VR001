using UnityEngine;

public class GhostConfusedState : IState
{
    private GhostStateManager ghost;
    private float timer = 0f;
    private float waitTime = 3f;

    public GhostConfusedState(GhostStateManager g)
    {
        ghost = g;
    }

    public void OnEnter()
    {
        Debug.Log("Enter CONFUSED");
        ghost.ghostAnimator.SetBool("isChasing", false);
        ghost.ghostAnimator.SetBool("isPatrol", false);
        ghost.agent.ResetPath();
        timer = 0f;
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ghost.SetState(ghost.patrolState);
        }
    }

    public void OnExit()
    {
        Debug.Log("Exit CONFUSED");
    }
}
