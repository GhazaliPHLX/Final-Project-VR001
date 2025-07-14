using UnityEngine;
using VR001;

public class WalkingState : IState
{
    private readonly StateManager manager;

    public WalkingState(StateManager m) => manager = m;

    public void OnEnter()
    {
        Debug.Log("Enter Walking");
        manager.controller.moveSpeed = 3f;

        if (manager.animator != null)
            manager.animator.SetBool("isWalking", true);
    }

    public void OnUpdate()
    {
        // (optional: bisa isi logika tambahan)
    }

    public void OnExit()
    {
        Debug.Log("Exit Walking");

        if (manager.animator != null)
            manager.animator.SetBool("isWalking", false);
    }
}
