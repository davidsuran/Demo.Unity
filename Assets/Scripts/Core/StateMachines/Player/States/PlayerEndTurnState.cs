using Assets.Scripts.Core.Providers;
using Assets.Scripts.Core.StateMachines.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerEndTurnState : PlayerBaseState
    {
        private const float AnimationDampTime = 0.1f;
        private const float CrossFadeDuration = 0.5f;

        public override string Name => nameof(PlayerEndTurnState);


        public PlayerEndTurnState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.Velocity.y = 0f;

            StateMachine.Animator.CrossFadeInFixedTime(StateMachine.Unit.Animation.Walk, CrossFadeDuration);

            InputReaderStateMachine.Instance.OnCancelPerformed += SwitchToMoveState;

            BattlefieldProvider.Instance.ShowEndTurnDialog();

            //StateMachine.HealthPointsComponent.OnZeroHealthPerformed += SwitchToDeathState;
            //StateMachine.HitableComponent.OnFireHitReceivedEvent += TakeDamage;

            //foreach (Core.Components.CritableComponent critable in StateMachine.CritableComponents)
            //{
            //    critable.OnFireHitReceivedEvent += TakeDamage;
            //}
        }

        public override void Exit()
        {
            InputReaderStateMachine.Instance.OnCancelPerformed -= SwitchToMoveState;


            BattlefieldProvider.Instance.HideEndTurnDialog();

            //StateMachine.HealthPointsComponent.OnZeroHealthPerformed -= SwitchToDeathState;
            //StateMachine.HitableComponent.OnFireHitReceivedEvent -= TakeDamage;

            //foreach (Core.Components.CritableComponent critable in StateMachine.CritableComponents)
            //{
            //    critable.OnFireHitReceivedEvent -= TakeDamage;
            //}
        }

        public override void Tick()
        {
            if (!StateMachine.Controller.isGrounded)
            {
                ApplyGravity();
                //Move();
            }
        }
    }
}
