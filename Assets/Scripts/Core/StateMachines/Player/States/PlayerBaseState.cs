using Assets.Scripts.Battlefield.Data.StateMachine;
using Assets.Scripts.Core.StateMachines.Inputs;
using Scripts.Common.EventArguments;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public abstract class PlayerBaseState : StateMachineState
    {
        protected readonly PlayerStateMachine StateMachine;

        protected PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.StateMachine = stateMachine;
        }

        protected void CalculateMoveDirection()
        {
            Vector3 cameraForward = new(StateMachine.MainCamera.forward.x, 0, StateMachine.MainCamera.forward.z);
            Vector3 cameraRight = new(StateMachine.MainCamera.right.x, 0, StateMachine.MainCamera.right.z);

            //Vector3 moveDirection = cameraForward.normalized * StateMachine.InputReader.MoveComposite.y + cameraRight.normalized * StateMachine.InputReader.MoveComposite.x;

            Vector3 moveDirection = cameraForward.normalized * InputReaderStateMachine.Instance.MoveComposite.y 
                + cameraRight.normalized * InputReaderStateMachine.Instance.MoveComposite.x;

            //DrawLine(StateMachine.transform.position, moveDirection);

            StateMachine.Velocity.x = moveDirection.x * StateMachine.MovementSpeed;
            StateMachine.Velocity.z = moveDirection.z * StateMachine.MovementSpeed;
        }

        protected void FaceMoveDirection()
        {
            Vector3 faceDirection = new(StateMachine.Velocity.x, 0f, StateMachine.Velocity.z);

            if (faceDirection == Vector3.zero)
            {
                return;
            }

            StateMachine.transform.rotation = Quaternion.Slerp(StateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), StateMachine.LookRotationDampFactor * Time.deltaTime);
        }

        protected void ApplyGravity()
        {
            if (StateMachine.Velocity.y > Physics.gravity.y)
            {
                StateMachine.Velocity.y += Physics.gravity.y * Time.deltaTime;
            }
        }

        /// <summary>
        /// Moves this instance.
        /// </summary>
        /// <returns></returns>
        protected float Move()
        {
            Vector3 beforeMove = StateMachine.transform.position;
            
            StateMachine.Controller.Move(StateMachine.Velocity * Time.deltaTime);
            
            Vector3 afterMove = StateMachine.transform.position;

            return Vector3.Distance(beforeMove, afterMove);
        }

        protected void SwitchToFallState()
        {
            StateMachine.SwitchState(new PlayerFallState(StateMachine));
            StateMachine.MachineGunStateMachine?.SwitchToIdleState();
        }

        protected void SwitchToDeathState()
        {
            StateMachine.SwitchState(new PlayerDeathState(StateMachine));
            StateMachine.MachineGunStateMachine?.SwitchToIdleState();
        }

        protected void SwitchToMoveState()
        {
            StateMachine.SwitchState(new PlayerMoveState(StateMachine));
            StateMachine.MachineGunStateMachine?.SwitchToIdleState();
        }

        protected void SwitchToPrepareActionState()
        {
            StateMachine.SwitchState(new PlayerPreparingActionState(StateMachine));
            StateMachine.MachineGunStateMachine?.SwitchToAimState();
        }

        protected void SwitchToEndTurnState()
        {
            StateMachine.SwitchState(new PlayerEndTurnState(StateMachine));
            StateMachine.MachineGunStateMachine?.SwitchToIdleState();
        }

        protected void SwitchToShootingState()
        {
            StateMachine.SwitchState(new PlayerTakingActionState(StateMachine));
            StateMachine.MachineGunStateMachine?.SwitchToShootingState();
        }

        protected void FaceCameraDirection()
        {
            Vector3 cameraForward = new(StateMachine.MainCamera.forward.x, 0, StateMachine.MainCamera.forward.z);
            Vector3 cameraRight = new(StateMachine.MainCamera.right.x, 0, StateMachine.MainCamera.right.z);
            Vector3 faceDirection = new(StateMachine.Velocity.x, 0f, StateMachine.Velocity.z);

            faceDirection = new(StateMachine.Velocity.x, 0f, StateMachine.Velocity.z);

            //PlayerTransform.rotation = Quaternion.Euler(0, CameraTransform.eulerAngles.y, 0);


            //if (faceDirection == Vector3.zero)
            //    return;

            //StateMachine.transform.rotation = Quaternion.Slerp(StateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), StateMachine.LookRotationDampFactor * Time.deltaTime);
            StateMachine.transform.rotation = Quaternion.Slerp(StateMachine.transform.rotation, Quaternion.Euler(0, StateMachine.MainCamera.eulerAngles.y, 0), StateMachine.LookRotationDampFactor * Time.deltaTime);
        }

        protected void TakeDamage(object sender, OnHitArgs args)
        {
            StateMachine.HealthPointsComponent.TakeDamage(args.Damage);
        }

        private LineRenderer lineRenderer;

        private void DrawLine(Vector3 start, Vector3 end)
        {
            //For creating line renderer object
            lineRenderer = lineRenderer ?? new GameObject("Line").AddComponent<LineRenderer>();
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = 1.01f;
            lineRenderer.endWidth = 1.01f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;

            //For drawing line in the world space, provide the x,y,z values
            lineRenderer.SetPosition(0, start); //x,y and z position of the starting point of the line
            lineRenderer.SetPosition(1, end); //x,y and z position of the end point of the line
        }

        protected void Vulnerable()
        {
            StateMachine.HealthPointsComponent.OnZeroHealthPerformed += SwitchToDeathState;
            StateMachine.HitableComponent.OnFireHitReceivedEvent += TakeDamage;

            foreach (Core.Components.CritableComponent critable in StateMachine.CritableComponents)
            {
                critable.OnFireHitReceivedEvent += TakeDamage;
            }
        }

        protected void Invulnerable()
        {
            StateMachine.HealthPointsComponent.OnZeroHealthPerformed -= SwitchToDeathState;
            StateMachine.HitableComponent.OnFireHitReceivedEvent -= TakeDamage;

            foreach (Core.Components.CritableComponent critable in StateMachine.CritableComponents)
            {
                critable.OnFireHitReceivedEvent -= TakeDamage;
            }
        }

        protected void ActionSwitchingEnable()
        {
            //StateMachine.ActionSwitchingComponent.OnLeftPerformed += SwitchToDeathState;
            //StateMachine.ActionSwitchingComponent.OnRightPerformed += SwitchToDeathState;
        }

        protected void ActionSwitchingDisable()
        {
            //StateMachine.ActionSwitchingComponent.OnLeftPerformed -= SwitchToDeathState;
            //StateMachine.ActionSwitchingComponent.OnRightPerformed -= SwitchToDeathState;
        }
    }
}
