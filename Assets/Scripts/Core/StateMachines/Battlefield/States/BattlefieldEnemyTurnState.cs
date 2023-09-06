using Assets.Scripts.Core.StateMachines.Battlefield;
using System;

namespace Assets.Scripts.StateMachines.Battlefield.States
{
    public class BattlefieldEnemyTurnState : BattlefieldBaseState
    {
        public override string Name => nameof(BattlefieldEnemyTurnState);

        public BattlefieldEnemyTurnState(BattlefieldStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override void Tick()
        {
        }
    }
}
