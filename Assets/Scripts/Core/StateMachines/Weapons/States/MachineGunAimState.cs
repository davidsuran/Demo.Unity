
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Weapons.States
{
    public class MachineGunAimState : MachineGunBaseState
    {
        private const int RESOURCE_ARC = 5;
        private const int RESOURCE_POINT = 6;
        
        private const int LINE_RANGE = 100;

        private GameObject _arcPrefab;
        private GameObject _pointPrefab;

        public override string Name => nameof(MachineGunAimState);

        public MachineGunAimState(MachineGunStateMachine stateMachine) : base(stateMachine)
        {
            //if (_arcPrefab == null)
            //{
            //    _arcPrefab = ResourceLoader.LoadPrefab(RESOURCE_ARC);
            //}

            //if (_pointPrefab == null)
            //{
            //    _pointPrefab = ResourceLoader.LoadPrefab(RESOURCE_POINT);
            //}

            //AnimationEvent evt = new AnimationEvent();
            //evt.intParameter = 12345;
            //evt.time = 1.1f;
            //evt.functionName = "AimingEnd";

            //var clipinfo = StateMachine.Animator.GetCurrentAnimatorClipInfo(0);

            //var clip = clipinfo.First().clip;
            //clip.AddEvent(evt);

        }

        public override void Enter()
        {




            //InputReaderStateMachine.Instance.OnCancelAimingPerformed += SwitchToIdleState;
            //InputReaderStateMachine.Instance.OnShootPerformed += SwitchToShootingState;
        }

        public override void Exit()
        {
            //InputReaderStateMachine.Instance.OnCancelAimingPerformed -= SwitchToIdleState;
            //InputReaderStateMachine.Instance.OnShootPerformed -= SwitchToShootingState;
        }

        public override void Tick()
        {
        }


    }
}
