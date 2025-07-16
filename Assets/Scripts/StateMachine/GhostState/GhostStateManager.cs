using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float chaseRange = 10f;
    public float losePlayerDelay = 3f;

    [HideInInspector] public IState currentState;
    [HideInInspector] public GhostPatrolState patrolState;
    [HideInInspector] public GhostChaseState chaseState;
    [HideInInspector] public GhostConfusedState confusedState;

    private float lostPlayerTimer;
    public Animator ghostAnimator;
    public List<Transform> patrolPoints;

    private void Awake()
    {
        patrolState = new GhostPatrolState(this);
        chaseState = new GhostChaseState(this);
        confusedState = new GhostConfusedState(this);
        ghostAnimator = GetComponentInChildren<Animator>();


    }

    private void Start()
    {
        SetState(patrolState);
    }

    private void Update()
    {
        currentState?.OnUpdate();

        // Deteksi jarak ke player
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseRange)
        {
            SetState(chaseState);
            lostPlayerTimer = 0f;
        }
        else if (currentState == chaseState)
        {
            // Tambah waktu kehilangan jejak
            lostPlayerTimer += Time.deltaTime;

            if (lostPlayerTimer >= losePlayerDelay)
            {
                SetState(confusedState);
            }
        }
    }

    public void SetState(IState newState)
    {
        if (newState == currentState) return;

        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }
}
