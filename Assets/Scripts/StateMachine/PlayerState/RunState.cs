using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR001;

public class RunningState : IState
{
    private readonly StateManager manager;

    public RunningState(StateManager m) => manager = m;

    public void OnEnter()
    {
        Debug.Log("Enter Running");
        manager.controller.moveSpeed = 6f;
    }

    public void OnUpdate() { }

    public void OnExit()
    {
        Debug.Log("Exit Running");
    }
}

