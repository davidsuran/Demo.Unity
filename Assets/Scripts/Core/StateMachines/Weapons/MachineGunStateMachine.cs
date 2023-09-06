using Assets.Scripts.Battlefield.Data.StateMachine;
using Assets.Scripts.Core.StateMachines.Weapons.States;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Weapons
{
    public class MachineGunStateMachine : StateMachine
    {
        public float MovementSpeed { get; private set; } = 5f;
        public float LookRotationDampFactor { get; private set; } = 10f;
        //public InputReader InputReader { get; private set; }
        public Animator Animator { get; private set; }

        public Transform ProjectileSource { get; set; }

        public Transform BulletCasingSource { get; set; }


        public GameObjectPooler Pool;

        private void Start()
        {
            //InputReader = GetComponent<InputReader>();

            Animator = GetComponent<Animator>();

            ProjectileSource = transform.GetChild(0).GetChild(0).transform;

            BulletCasingSource = transform.GetChild(0).GetChild(1).transform;

            if (Pool == null)
            {
                throw new ArgumentNullException(nameof(Pool));
            }
            //Pool.Load(ProjectileSource);
            Pool.Load();

            SwitchToIdleState();
        }

        public void SwitchToAimState()
        {
            SwitchState(new MachineGunAimState(this));
        }

        public void SwitchToIdleState()
        {
            SwitchState(new MachineGunIdleState(this));
        }

        public void SwitchToShootingState()
        {
            SwitchState(new MachineGunShootingState(this));
        }
    }
}
