
using Assets.Scripts.Battlefield.Data.StateMachine;
using Assets.Scripts.Core.StateMachines.Battlefield;

namespace Assets.Scripts.StateMachines.Battlefield.States
{
    public abstract class BattlefieldBaseState : StateMachineState
    {
        protected readonly BattlefieldStateMachine StateMachine;

        protected BattlefieldBaseState(BattlefieldStateMachine stateMachine)
        {
            this.StateMachine = stateMachine;
        }
    }
}
