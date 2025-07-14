using UnityEngine;

namespace VR001
{
    public class StateManager : MonoBehaviour
    {
        [Header("References")]
        public NewFPS_Movement controller;

        [Header("Animation")]
        public Animator animator;

        private IdlingState idlingState;
        private WalkingState walkingState;

        private IState currentState;

        public IdlingState GetIdlingState() => idlingState;
        public WalkingState GetWalkingState() => walkingState;

        private void Awake()
        {
            controller = GetComponent<NewFPS_Movement>();

            animator = GetComponentInChildren<Animator>();

            idlingState = new IdlingState(this);
            walkingState = new WalkingState(this);
        }

        private void Start()
        {
            SetState(idlingState);
        }

        private void Update()
        {
            currentState?.OnUpdate();

            if (controller == null) return;

            if (controller.IsMoving)
            {
                SetState(walkingState);
            }
            else
            {
                SetState(idlingState);
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
}
