using Assets.Scripts.Core.StateMachines.Inputs;
using UnityEngine;


namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerJumpState : PlayerBaseState
    {
        private readonly int JumpHash = Animator.StringToHash("Jump");
        private const float CrossFadeDuration = 0.1f;
        public override string Name => nameof(PlayerJumpState);

        public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            InputReaderStateMachine.Instance.SwitchToMovingState();

            StateMachine.Velocity = new Vector3(StateMachine.Velocity.x, StateMachine.JumpForce, StateMachine.Velocity.z);

            //StateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);

            Vulnerable();
        }
        
        public override void Exit()
        {
            Invulnerable();
        }

        public override void Tick()
        {
            ApplyGravity();

            if (StateMachine.Velocity.y <= 0f)
            {
                SwitchToFallState();
            }

            FaceMoveDirection();
            Move();
        }
    }
}
