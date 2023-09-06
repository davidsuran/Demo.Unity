using System;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Core.StateMachines.Inputs
{
    public class InputReaderPlayerPreparingActionState : InputReaderBaseState, PlayerControls.IPlayerPreparingActions
    {
        public override string Name => nameof(InputReaderPlayerPreparingActionState);

        public InputReaderPlayerPreparingActionState(InputReaderStateMachine stateMachine) : base(stateMachine)
        {
            StateMachine.Controls.PlayerPreparing.SetCallbacks(this);
        }

        public override void Enter()
        {
            base.Enter();
            StateMachine.Controls.PlayerPreparing.Enable();
        }

        public override void Exit()
        {
            base.Exit();
            StateMachine.Controls.PlayerPreparing.Disable();
        }

        public override void Tick()
        {
            throw new NotImplementedException();
        }

        public void OnPerformAction(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            StateMachine.OnShootPerformed?.Invoke();
        }

        public void OnCancelAction(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            StateMachine.OnCancelAimingPerformed?.Invoke();
        }
    }
}
