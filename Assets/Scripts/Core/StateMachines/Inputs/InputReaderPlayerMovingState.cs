using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Core.StateMachines.Inputs
{
    public class InputReaderPlayerMovingState : InputReaderBaseState, PlayerControls.IPlayerMovingActions
    {
        public override string Name => nameof(InputReaderPlayerMovingState);


        public InputReaderPlayerMovingState(InputReaderStateMachine stateMachine) : base(stateMachine)
        {
            StateMachine.Controls.PlayerMoving.SetCallbacks(this);
        }

        public override void Enter()
        {
            base.Enter();
            StateMachine.Controls.PlayerMoving.Enable();
        }

        public override void Exit()
        {
            base.Exit();
            StateMachine.Controls.PlayerMoving.Disable();
        }

        public override void Tick()
        {
            throw new NotImplementedException();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            StateMachine.MoveComposite = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            StateMachine.OnJumpPerformed?.Invoke();
        }

        public void OnCancelAiming(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            StateMachine.Controls.PlayerPreparing.Disable();

            StateMachine.OnCancelAimingPerformed?.Invoke();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            StateMachine.OnCancelPerformed?.Invoke();
        }

        public void OnPrepareAction(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            StateMachine.OnPrepareActionPerformed?.Invoke();
        }
    }
}
