using System;

namespace Assets.Scripts.Core.StateMachines.Player.States
{
    public class PlayerNotMyTurnState : PlayerBaseState
    {
        public PlayerNotMyTurnState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override string Name => nameof(PlayerNotMyTurnState);

        public override void Enter()
        {
            Vulnerable();
        }

        public override void Exit()
        {
            Invulnerable();
        }

        public override void Tick()
        {
        }
    }
}
