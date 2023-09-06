
using Assets.Scripts.Core.StateMachines.Player.States;

namespace Assets.Scripts.Core.StateMachines.Weapons.States
{
    public class MachineGunIdleState : MachineGunBaseState
    {
        public override string Name => nameof(MachineGunIdleState);

        public MachineGunIdleState(MachineGunStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {

            //InputReaderStateMachine.Instance.OnAimPerformed += SwitchToAimState;
        }

        public override void Exit()
        {
            //InputReaderStateMachine.Instance.OnAimPerformed -= SwitchToAimState;
        }

        public override void Tick()
        {
        }
    }
}
