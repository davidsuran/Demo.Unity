using Assets.Scripts.Core.Providers;
using UnityEngine;
using static Assets.Ui.Scripts.Battlefield.ButtonUiComponent;

namespace Assets.Ui.Scripts.Battlefield.Player
{
    public class EndTurnDialogComponent : MonoBehaviour
    {
        private ButtonUiComponent _buttonYes;
        private ButtonUiComponent _buttonNo;

        void OnEnable()
        {
            _buttonYes = transform.GetChild(1).GetComponent<ButtonUiComponent>();
            _buttonYes.ButtonPressEventHandler += EndCurrentPlayerTurn;

            _buttonNo = transform.GetChild(2).GetComponent<ButtonUiComponent>();
            _buttonNo.ButtonPressEventHandler += HideEndTurnDialog;

            transform.SetAsLastSibling();
        }

        private void EndCurrentPlayerTurn(object sender, ButtonUiComponentEventArgs e)
        {
            UnsubscribeButtonEvents();
            BattlefieldProvider.Instance.EndActivePlayerTurn();
            Debug.Log("end current player turn");
        }

        private void HideEndTurnDialog(object sender, ButtonUiComponentEventArgs e)
        {
            UnsubscribeButtonEvents();
            BattlefieldProvider.Instance.HideEndTurnDialog();

            if (e.Text.ToLower() == "yes")
            {
                //BattlefieldProvider.Instance.EndActivePlayerTurn();
            }
            else
            {
                ActiveUnitProvider.Instance.CancelEndTurn();
            }
        }

        private void UnsubscribeButtonEvents()
        {
            if (_buttonYes != null)
            {
                _buttonYes.ButtonPressEventHandler -= EndCurrentPlayerTurn;
            }

            if (_buttonNo != null)
            {
                _buttonNo.ButtonPressEventHandler -= HideEndTurnDialog;
            }
        }
    }
}
