using Assets.Scripts.Battlefield.Data.StateMachine;
using System;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Inputs
{
    public class InputReaderStateMachine
    {
        public Vector2 MoveComposite;

        public Action OnJumpPerformed;
        public Action OnShootPerformed;
        public Action OnPrepareActionPerformed;
        public Action OnCancelAimingPerformed;
        public Action OnCancelPerformed;
        public Action OnSwitchActionRight;
        public Action OnSwitchActionLeft;

        public PlayerControls Controls;

        /// <summary>
        /// The current state
        /// </summary>
        private StateMachineState currentState;

        public string CurrentStateString { get; private set; }

        public static InputReaderStateMachine Instance => _lazy.Value;        
        
        private static readonly Lazy<InputReaderStateMachine> _lazy =
            new Lazy<InputReaderStateMachine>(() => new InputReaderStateMachine(), LazyThreadSafetyMode.ExecutionAndPublication);

        private InputReaderStateMachine()
        {
        }

        public void OnEnable()
        {
            if (Controls != null)
            {
                return;
            }

            Controls = new PlayerControls();

            SwitchState(new InputReaderPlayerMovingState(this));
        }

        public void Update()
        {
            //currentState?.Tick();
        }

        public void OnDisable()
        {
            Controls.PlayerMoving.Disable();
            Controls.PlayerPreparing.Disable();
            Controls.PlayerBase.Disable();
        }

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

        public void SwitchToPlayerPreparingActionState()
        {
            SwitchState(new InputReaderPlayerPreparingActionState(this));
        }

        public void SwitchToMovingState()
        {
            SwitchState(new InputReaderPlayerMovingState(this));
        }
    }
}
