using Assets.Scripts.Battlefield.Data.StateMachine;

namespace Assets.Scripts.Core.StateMachines.Weapons.States
{
    public abstract class MachineGunBaseState : StateMachineState
    {

        protected readonly MachineGunStateMachine StateMachine;

        protected MachineGunBaseState(MachineGunStateMachine stateMachine)
        {
            this.StateMachine = stateMachine;
        }

        protected void SwitchToAimState()
        {
            StateMachine.SwitchState(new MachineGunAimState(StateMachine));
        }

        public void SwitchToIdleState()
        {
            StateMachine.SwitchState(new MachineGunIdleState(StateMachine));
        }

        public void SwitchToShootingState()
        {
            StateMachine.SwitchState(new MachineGunShootingState(StateMachine));
        }
    }
}
