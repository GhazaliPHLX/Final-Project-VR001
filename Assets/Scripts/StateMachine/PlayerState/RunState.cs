using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR001;

public class RunningState : MonoBehaviour, IState
{
    private StateManager stateManager;
    public RunningState(StateManager manager)
    {
        this.stateManager = manager;
    }
    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }

}
