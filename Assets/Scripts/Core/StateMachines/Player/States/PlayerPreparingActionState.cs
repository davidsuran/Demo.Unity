using Assets.Scripts.Core.AimArc;
using Assets.Scripts.Battlefield.Data.Serializable;
using Assets.Scripts.Core.StateMachines.Inputs;
using Assets.Scripts.Core.StateMachines.Weapons;
using Codice.CM.Client.Differences.Graphic;
using log4net.Util;
using System;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Core.Providers;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerPreparingActionState : PlayerBaseState
    {
        private readonly int ShootHash = Animator.StringToHash("gun_animation");
        private const float CrossFadeDuration = 0.1f;

        //private const int RESOURCE_ARC = 5;
        //private const int RESOURCE_POINT = 6;

        //private const int LINE_RANGE = 100;

        //private GameObject _arcPrefab;
        //private GameObject _pointPrefab;

        //private GameObject _line;

        private Assets.Scripts.Core.AimArc.AimArc _aimArc;

        public override string Name => nameof(PlayerPreparingActionState);

        public PlayerPreparingActionState(PlayerStateMachine stateMachine) : base(stateMachine)
        {

        }

        /// <summary>
        /// Enters this instance.
        /// </summary>
        public override void Enter()
        {
            _aimArc = _aimArc ?? new Assets.Scripts.Core.AimArc.AimArc(StateMachine.MachineGunStateMachine.ProjectileSource);

            InputReaderStateMachine.Instance.SwitchToPlayerPreparingActionState();

            InputReaderStateMachine.Instance.OnCancelAimingPerformed += SwitchToMoveState;

            //stateMachine.Velocity = new Vector3(stateMachine.Velocity.x, stateMachine.JumpForce, stateMachine.Velocity.z);

            AnimationEvent evt = new AnimationEvent();
            evt.intParameter = 12345;
            evt.time = 1.1f;
            evt.functionName = nameof(PlayerStateMachine.AimingEnd);

            AnimationClip clip = StateMachine.Animator.runtimeAnimatorController.animationClips
                .Single(_ => _.name == "gun_animation");

            //if (!clip.events.Select(_ => _.functionName).Contains(evt.functionName))
            //{
            //    clip.AddEvent(evt);
            //}

            if (clip.events.Count() < 1)
            {
                clip.AddEvent(evt);
            }

            if (!StateMachine.Animator.isInitialized)
            {

                StateMachine.Animator.Rebind();
                Debug.Log("not initialized");
            }

            StateMachine.Animator.CrossFadeInFixedTime(StateMachine.Unit.Animation.PrepareAttack, CrossFadeDuration);

            BattlefieldProvider.Instance.ShowCrosshair();
        }

        /// <summary>
        /// Exits this instance.
        /// </summary>
        public override void Exit()
        {
            InputReaderStateMachine.Instance.OnCancelAimingPerformed -= SwitchToMoveState;
            InputReaderStateMachine.Instance.OnShootPerformed -= SwitchToShootingState;

            _aimArc?.HideLine();
            BattlefieldProvider.Instance.HideCrosshair();
        }

        /// <summary>
        /// Ticks this instance.
        /// </summary>
        public override void Tick()
        {
            FaceCameraDirection();
            UpdateAimLine();
        }

        /// <summary>
        /// Shows the aim line.
        /// </summary>
        internal void ShowAimLine()
        {
            _aimArc?.ShowLine();
            InputReaderStateMachine.Instance.OnShootPerformed += SwitchToShootingState;
        }

        /// <summary>
        /// Updates the aim line.
        /// </summary>
        private void UpdateAimLine()
        {
            _aimArc?.Update();
        }
    }
}
