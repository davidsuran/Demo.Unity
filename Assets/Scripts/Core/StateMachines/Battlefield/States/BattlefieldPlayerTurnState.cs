using Assets.Scripts.Core.StateMachines.Battlefield;
using Assets.Scripts.Core.StateMachines.Player.States;
using System;

namespace Assets.Scripts.StateMachines.Battlefield.States
{
    public class BattlefieldPlayerTurnState : BattlefieldBaseState
    {

        public override string Name => nameof(BattlefieldPlayerTurnState);

        public BattlefieldPlayerTurnState(BattlefieldStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            // switch to control player
        }

        public override void Exit()
        {
        }

        public override void Tick()
        {
        }
    }
}
