using UnityEngine;

namespace Assets.Scripts.Battlefield.Data.StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        /// <summary>
        /// The current state string
        /// </summary>
        public string CurrentStateString;

        /// <summary>
        /// The current state
        /// </summary>
        protected StateMachineState currentState;

        /// <summary>
        /// Switchs the state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SwitchState(StateMachineState state)
        {
            currentState?.Exit();
            currentState = state;
            CurrentStateString = state.GetType().Name;
            currentState.Enter();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update()
        {
            currentState?.Tick();
        }
    }
}
