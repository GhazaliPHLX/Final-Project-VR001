using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR001;

public class IdlingState : IState
{
    private readonly StateManager manager;

    public IdlingState(StateManager m) => manager = m;

    public void OnEnter()
    {
        Debug.Log("Enter Idle");
        manager.controller.moveSpeed = 0f;

        if (manager.animator != null)
            manager.animator.SetBool("isWalking", false);
    }

    public void OnUpdate() { }

    public void OnExit()
    {
        Debug.Log("Exit Idle");
        manager.animator.SetBool("isWalking", false);
    }
}



