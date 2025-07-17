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
    private float confusedTimer;
    public float confusedDuration = 3f;

    public Animator ghostAnimator;
    public List<Transform> patrolPoints;

    [Header("Player Visibility")]
    public bool isPlayerVisible = true;

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
        // Kalau di ConfusedState, hitung mundur dulu
        if (currentState == confusedState)
        {
            confusedTimer += Time.deltaTime;
            if (confusedTimer >= confusedDuration)
            {
                SetState(patrolState);
                confusedTimer = 0f;
            }
            return;
        }

        // Kalau player ilang atau sembunyi
        if (!isPlayerVisible || player == null)
        {
            if (currentState != patrolState)
                SetState(patrolState);
            return;
        }

        if (!player.CompareTag("Player"))
        {
            player = null;
            EnterConfusedState();
            return;
        }

        currentState?.OnUpdate();

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseRange)
        {
            SetState(chaseState);
            lostPlayerTimer = 0f;
        }
        else if (currentState == chaseState)
        {
            lostPlayerTimer += Time.deltaTime;

            if (lostPlayerTimer >= losePlayerDelay)
            {
                EnterConfusedState();
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

    // Fungsi tambahan
    private void EnterConfusedState()
    {
        confusedTimer = 0f;
        SetState(confusedState);
    }

    public void SetPlayerVisibility(bool visible)
    {
        isPlayerVisible = visible;
    }
}
