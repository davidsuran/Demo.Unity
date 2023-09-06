using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerDeathState : PlayerBaseState
    {
        private const float CrossFadeDuration = 0.1f;
        public override string Name => nameof(PlayerDeathState);

        public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            //stateMachine.Velocity = new Vector3(stateMachine.Velocity.x, stateMachine.JumpForce, stateMachine.Velocity.z);

            StateMachine.Animator.CrossFadeInFixedTime(StateMachine.Unit.Animation.Death, CrossFadeDuration);

            StateMachine.Rigidbody.isKinematic = false;
            //StateMachine.HitableComponent.Rigidbody.isKinematic = false;
        }

        public override void Exit()
        {
        }

        public override void Tick()
        {
            //ApplyGravity();

            //if (stateMachine.Velocity.y <= 0f)
            //{
            //    stateMachine.SwitchState(new PlayerFallState(stateMachine));
            //}

            FaceMoveDirection();
            //Move();
        }
    }
}
