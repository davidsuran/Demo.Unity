using Assets.Scripts.Core.StateMachines.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    class PlayerZeroActionPointsState : PlayerBaseState
    {
        private readonly int ShootHash = Animator.StringToHash("gun_animation");
        private const float CrossFadeDuration = 0.1f;

        public override string Name => nameof(PlayerZeroActionPointsState);

        public PlayerZeroActionPointsState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            InputReaderStateMachine.Instance.SwitchToMovingState();

            InputReaderStateMachine.Instance.OnPrepareActionPerformed += SwitchToPrepareActionState;
            InputReaderStateMachine.Instance.OnCancelPerformed += SwitchToEndTurnState;

            Vulnerable();
        }

        public override void Exit()
        {
            InputReaderStateMachine.Instance.OnPrepareActionPerformed -= SwitchToPrepareActionState;
            InputReaderStateMachine.Instance.OnCancelPerformed -= SwitchToEndTurnState;

            Invulnerable();
        }

        public override void Tick()
        {
            FaceCameraDirection();
        }
    }
}
