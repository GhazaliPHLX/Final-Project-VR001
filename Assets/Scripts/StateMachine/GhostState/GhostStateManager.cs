using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator ghostAnimator;
    public List<Transform> patrolPoints;
    public float chaseRange = 10f;
    public GhostAudio ghostAudio;

    [HideInInspector] public GhostPatrolState patrolState;
    [HideInInspector] public GhostChaseState chaseState;
    [HideInInspector] public GhostConfusedState confusedState;

    private IState currentState;
    public int currentPatrolIndex = 0;

    void Start()
    {
        patrolState = new GhostPatrolState(this);
        chaseState = new GhostChaseState(this);
        confusedState = new GhostConfusedState(this);
        ghostAudio = GetComponent<GhostAudio>();

        SetState(patrolState);
    }

    void Update()
    {
        if (player != null && currentState == chaseState && !player.CompareTag("Player"))
        {
            player = null;
            SetState(confusedState);
            return;
        }

        float distanceToPlayer = player != null ? Vector3.Distance(transform.position, player.position) : Mathf.Infinity;
        if (player != null && distanceToPlayer <= chaseRange && currentState != chaseState)
        {
            SetState(chaseState);
            return;
        }

        currentState?.OnUpdate();
    }

    public void SetState(IState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState?.OnEnter();
    }
}
