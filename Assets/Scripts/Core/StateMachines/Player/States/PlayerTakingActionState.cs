using Assets.Scripts.Core.StateMachines.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerTakingActionState : PlayerBaseState
    {
        private readonly int ShootHash = Animator.StringToHash("gun_animation");
        private const float CrossFadeDuration = 0.1f;

        public override string Name => nameof(PlayerTakingActionState);

        public PlayerTakingActionState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            InputReaderStateMachine.Instance.OnCancelAimingPerformed += SwitchToMoveState;
        }

        public override void Exit()
        {
            InputReaderStateMachine.Instance.OnCancelAimingPerformed -= SwitchToMoveState;
        }

        public override void Tick()
        {
        }
    }
}
