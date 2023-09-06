using UnityEngine;


namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerFallState : PlayerBaseState
    {
        private readonly int FallHash = Animator.StringToHash("Fall");
        private const float CrossFadeDuration = 0.1f;
        public override string Name => nameof(PlayerFallState);

        public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.Velocity.y = 0f;

            //StateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);

            Vulnerable();
        }

        public override void Exit()
        {
            Invulnerable();
        }

        public override void Tick()
        {
            //Debug.Log("falling");
            ApplyGravity();
            Move();

            if (StateMachine.Controller.isGrounded)
            {
                SwitchToMoveState();
            }
        }
    }
}
