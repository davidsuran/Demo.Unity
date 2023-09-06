using Assets.Scripts.Core.StateMachines.Inputs;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerMoveState : PlayerBaseState
    {
        private readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
        private readonly int MoveBlendTreeHash = Animator.StringToHash("walk_animation");
        private const float AnimationDampTime = 0.1f;
        private const float CrossFadeDuration = 0.5f;

        public override string Name => nameof(PlayerMoveState);

        public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.Velocity.y = Physics.gravity.y;

            StateMachine.Animator.CrossFadeInFixedTime(MoveBlendTreeHash, CrossFadeDuration);

            InputReaderStateMachine.Instance.SwitchToMovingState();

            InputReaderStateMachine.Instance.OnJumpPerformed += SwitchToJumpState;
            InputReaderStateMachine.Instance.OnPrepareActionPerformed += SwitchToPrepareActionState;
            InputReaderStateMachine.Instance.OnCancelPerformed += SwitchToEndTurnState;

            StateMachine.ActionPointsComponent.OnZeroActionPointsPerformed += SwitchToZeroActionPointsState;

            Vulnerable();
        }

        public override void Exit()
        {
            InputReaderStateMachine.Instance.OnJumpPerformed -= SwitchToJumpState;
            InputReaderStateMachine.Instance.OnPrepareActionPerformed -= SwitchToPrepareActionState;
            InputReaderStateMachine.Instance.OnCancelPerformed -= SwitchToEndTurnState;

            StateMachine.ActionPointsComponent.OnZeroActionPointsPerformed -= SwitchToZeroActionPointsState;

            Invulnerable();
            //UnSubscribeToEvenets();
        }

        public override void Tick()
        {
            if (!StateMachine.Controller.isGrounded)
            {
                SwitchToFallState();
            }

            CalculateMoveDirection();
            FaceMoveDirection();

            StateMachine.ActionPointsComponent.DistanceTraveled(
                Move()
            );

            //StateMachine.Animator.SetFloat(MoveSpeedHash, StateMachine.InputReader.MoveComposite.sqrMagnitude > 0f ? 1f : 0f, AnimationDampTime, Time.deltaTime);
        }

        private void SwitchToJumpState()
        {
            StateMachine.SwitchState(new PlayerJumpState(StateMachine));
        }

        private void SwitchToZeroActionPointsState()
        {
            StateMachine.SwitchState(new PlayerZeroActionPointsState(StateMachine));
        }


        //private void SubscribeToEvenets()
        //{
        //    SetEvents((Action x, Action y) => x = (Action)Action.Combine(x, y));
        //}

        //private void UnSubscribeToEvenets()
        //{
        //    SetEvents((Action x, Action y) => x = (Action)Action.Remove(x, y));
        //}

        //private void SetEvents(Action<Action, Action> action)
        //{
        //    action(StateMachine.InputReader.OnJumpPerformed, SwitchToJumpState);
        //    action(StateMachine.InputReader.OnAimPerformed, SwitchToAimState);
        //    action(StateMachine.HealthPointsComponent.OnZeroHealthPerformed, () => SwitchToDeathState());
        //    action(StateMachine.ActionPointsComponent.OnZeroActionPointsPerformed, () => SwitchToZeroActionPointsState());
        //}
    }
}
