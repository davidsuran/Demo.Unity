using Assets.Scripts.Core.Providers;
using Assets.Scripts.StateMachines.Battlefield.States;

namespace Assets.Scripts.Core.StateMachines.Battlefield.States
{
    public class BattlefieldEndOfTurnState : BattlefieldBaseState
    {
        public BattlefieldEndOfTurnState(BattlefieldStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override string Name =>nameof(BattlefieldEndOfTurnState);

        public override void Enter()
        {
            ActiveUnitProvider.Instance.EndActivePlayerTurn();

            // Find out whos next

            if (StateMachine.CurrentSquad.CurrentTokens >= 0)
            {
                StateMachine.BattlefieldUiViewController.ShowUnitListDialog();
            }
        }

        public override void Exit()
        {
        }

        public override void Tick()
        {
        }
    }
}
