using Assets.Scripts.Core.StateMachines.Player.States;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Weapons.States
{
    public class MachineGunShootingState : MachineGunBaseState
    {
        private const string RESOURCE_BULLET = "Bullet";

        private const string RESOURCE_BULLET_CASING = "BulletCasing";

        public override string Name => nameof(MachineGunShootingState);


        List<GameObject> Bullets = new List<GameObject>();
        List<GameObject> BulletCasings = new List<GameObject>();

        public MachineGunShootingState(MachineGunStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {

            Debug.Log("Shooting");


            //InputReaderStateMachine.Instance.OnCancelAimingPerformed += SwitchToIdleState;
        }

        public override void Exit()
        {
            //InputReaderStateMachine.Instance.OnCancelAimingPerformed -= SwitchToIdleState;

            foreach (GameObject bullet in Bullets)
            {
                StateMachine.Pool.ReturnToPool(RESOURCE_BULLET, bullet);
            }
            
            foreach (GameObject bulletCasings in BulletCasings)
            {
                StateMachine.Pool.ReturnToPool(RESOURCE_BULLET_CASING, bulletCasings);
            }

            Debug.Log("Bullets and casings returned");

        }

        public override void Tick()
        {
            Shoot();
        }

        float nextActionTime = 0.0f;
        float nextBulletCasingActionTime = 0.0f;
        bool finished = false;

        private void Shoot()
        {
            float period = 0.3f;
            nextActionTime = nextActionTime + Time.deltaTime;
            
            if (nextActionTime > period)
            {
                GameObject bullet = StateMachine.Pool.SpawnFromPool(RESOURCE_BULLET);
                
                nextActionTime = 0;

                if (bullet == null)
                {
                    finished = true;
                }
                else
                {
                    bullet.transform.position = StateMachine.ProjectileSource.position;
                    bullet.transform.localRotation = Quaternion.FromToRotation(Vector3.up, StateMachine.ProjectileSource.transform.up);

                    Bullets.Add(bullet);
                }

                if (finished)
                {
                    // TODO: inform parent
                    //SwitchToIdleState();
                }
            }

            float bulletCasingDelay = 0.1f;

            nextBulletCasingActionTime = nextBulletCasingActionTime + Time.deltaTime;

            if (nextBulletCasingActionTime - bulletCasingDelay > period)
            {
                GameObject bulletCasing = StateMachine.Pool.SpawnFromPool(RESOURCE_BULLET_CASING);
                if (bulletCasing != null)
                {
                    nextBulletCasingActionTime = 0;

                    bulletCasing.transform.position = StateMachine.BulletCasingSource.position;
                    bulletCasing.transform.rotation = StateMachine.transform.rotation;

                    BulletCasings.Add(bulletCasing);
                }
                else
                {
                    finished = true;
                }
            }
        }
    }
}
