using Assets.Scripts.Battlefield.Data.StateMachine;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Core.StateMachines.Inputs
{
    public abstract class InputReaderBaseState : StateMachineState, PlayerControls.IPlayerBaseActions
    {
        protected readonly InputReaderStateMachine StateMachine;
        public Vector2 MouseDelta;

        public InputReaderBaseState(InputReaderStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            StateMachine.Controls.PlayerBase.SetCallbacks(this);
        }

        public override void Enter()
        {
            StateMachine.Controls.PlayerBase.Enable();
        }

        public override void Exit()
        {
            StateMachine.Controls.PlayerBase.Disable();
        }

        public override void Tick()
        {
            throw new InvalidOperationException();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            MouseDelta = context.ReadValue<Vector2>();
        }

        public void OnSwitchActionRight(InputAction.CallbackContext context)
        {
            StateMachine.OnSwitchActionRight?.Invoke();
        }

        public void OnSwitchActionLeft(InputAction.CallbackContext context)
        {
            StateMachine.OnSwitchActionLeft?.Invoke();
        }
    }
}
