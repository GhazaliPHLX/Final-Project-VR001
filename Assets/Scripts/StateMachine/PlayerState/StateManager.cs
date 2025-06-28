using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR001
{
    public class StateManager : MonoBehaviour
    {
        #region Variables
        [Header("Config")]
        [SerializeField] private float _acceleration = 1f;
        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _attackDistance = 2f;
        public float IdlingTime = 3f;

        [Header("Value")]
        public float Speed;
        public bool IsAllowedToAttack;

        public GameObject Player;
        private float _distance;

        // Cache semua state
        private IdlingState idlingState;
        private RunningState runningState;
        private WalkingState walkingState;
        private AttackingState attackingState;

        private IState currentState;
        #endregion


        #region Getter State
        public IdlingState GetIdlingState() => idlingState;
        public WalkingState GetWalkingState() => walkingState;
        public RunningState GetRunningState() => runningState;
        public AttackingState GetAttackingState() => attackingState;
        #endregion


        private void Awake()
        {
            InitializeStates();

            Player = GameObject.FindGameObjectWithTag("Player");

            if (Player == null)
            {
                Debug.LogError("[StateManager] Player not found! Please tag the player object with 'Player'.");
            }
            else
            {
                Debug.Log("[StateManager] Player found and assigned.");
            }

            Speed = 0f;
            IsAllowedToAttack = false;
        }

        private void InitializeStates()
        {
            Debug.Log("[StateManager] Initializing states...");

            idlingState = new IdlingState(this);
            runningState = new RunningState(this);
            walkingState = new WalkingState(this);
            attackingState = new AttackingState(this);

            Debug.Log("[StateManager] All states initialized.");
        }

        private void Start()
        {
            SetState(idlingState);
            Debug.Log("[StateManager] Game started. Current state: Idling");
        }

        private void Update()
        {
            currentState.OnUpdate();

            if (Player == null) return;

            // Optional: Log distance every second for inspection
            if (Time.frameCount % 60 == 0)
            {
                Debug.Log($"[StateManager] Distance to player: {_distance:F2}, Speed: {Speed:F2}");
            }
        }

        public void CheckCanAttack()
        {
            bool wasAllowedToAttack = IsAllowedToAttack;
            IsAllowedToAttack = _distance <= _attackDistance;

            if (IsAllowedToAttack && !wasAllowedToAttack)
            {
                Debug.Log("[StateManager] Entered attack range.");
            }
            else if (!IsAllowedToAttack && wasAllowedToAttack)
            {
                Debug.Log("[StateManager] Exited attack range.");
            }
        }

        public void HandleMovement()
        {
            _distance = Vector3.Distance(transform.position, Player.transform.position);

            Speed += _acceleration * Time.deltaTime;
            Speed = Mathf.Min(Speed, _maxSpeed);

            Vector3 direction = (Player.transform.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;
        }

        public void SetState(IState newState)
        {
            if (newState == currentState) return;

            Debug.Log($"[StateManager] Transitioning from {currentState?.GetType().Name ?? "None"} to {newState.GetType().Name}");
            currentState?.OnExit();
            currentState = newState;
            currentState.OnEnter();
        }
    }
}
