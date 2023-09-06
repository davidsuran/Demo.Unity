using Assets.Scripts.Core.StateMachines.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerIdleState : PlayerBaseState
    {
        private readonly int MoveBlendTreeHash = Animator.StringToHash("walk_animation");
        private const float AnimationDampTime = 0.1f;
        private const float CrossFadeDuration = 0.5f;

        public override string Name => nameof(PlayerIdleState);


        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.Velocity.y = 0f;

            StateMachine.Animator.CrossFadeInFixedTime(MoveBlendTreeHash, CrossFadeDuration);

            Vulnerable();
        }

        public override void Exit()
        {
            Invulnerable();
        }

        public override void Tick()
        {
            if (!StateMachine.Controller.isGrounded)
            {
                ApplyGravity();
                Move();
            }
        }
    }
}
