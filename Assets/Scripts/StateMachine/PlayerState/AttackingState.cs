using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR001;

public class AttackingState : MonoBehaviour, IState
{
    private StateManager stateManager;
    public AttackingState(StateManager manager)
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
