using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR001;

public class IdlingState : MonoBehaviour, IState
{
    private StateManager stateManager;
    public IdlingState(StateManager manager)
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
