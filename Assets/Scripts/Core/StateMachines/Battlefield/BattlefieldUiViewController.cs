using Demo.Data;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Battlefield
{
    public class BattlefieldUiViewController
    {
        private const int UNIT_LIST_TABLE_ID = 2;
        private const int BATTLEFIELD_UI_ID = 3;

        private Transform _unitListTransform;
        private Transform _unitHealthPoints;
        private Transform _unitActionPoints;
        private Transform _unitEndTurnDialog;
        private Transform _actionSelectionPanel;
        private Transform _cursor;

        public BattlefieldUiViewController()
        {
            GameObject prefab = ResourceLoader.LoadUi(BATTLEFIELD_UI_ID);

            GameObject battleFieldUi = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);

            _unitListTransform = battleFieldUi.transform.GetChild(2);
            if (_unitListTransform.name != "UnitListTable")
            {
                throw new ArgumentException(FormattableString.Invariant($"{nameof(_unitListTransform)} is {_unitListTransform.name}, it should be UnitListTable"));
            }

            _unitHealthPoints = battleFieldUi.transform.GetChild(1).GetChild(0).GetChild(0);
            if (_unitHealthPoints.name != "HpBar")
            {
                throw new ArgumentException(FormattableString.Invariant($"{nameof(_unitHealthPoints)} is {_unitHealthPoints.name}, it should be HpBar"));
            }

            _unitActionPoints = battleFieldUi.transform.GetChild(1).GetChild(0).GetChild(1);
            if (_unitActionPoints.name != "ApBar")
            {
                throw new ArgumentException(FormattableString.Invariant($"{nameof(_unitActionPoints)} is {_unitActionPoints.name}, it should be ApBar"));
            }

            _unitEndTurnDialog = battleFieldUi.transform.GetChild(1).GetChild(0).GetChild(2);
            if (_unitEndTurnDialog.name != "EndTurnPanel")
            {
                throw new ArgumentException(FormattableString.Invariant($"{nameof(_unitEndTurnDialog)} is {_unitEndTurnDialog.name}, it should be EndTurnPanel"));
            }

            _actionSelectionPanel = battleFieldUi.transform.GetChild(1).GetChild(0).GetChild(3);
            if (_actionSelectionPanel.name != "ActionSelectionPanel")
            {
                throw new ArgumentException(FormattableString.Invariant($"{nameof(_actionSelectionPanel)} is {_actionSelectionPanel.name}, it should be ActionSelectionPanel"));
            }

            _cursor = battleFieldUi.transform.GetChild(1).GetChild(0).GetChild(4);
            if (_cursor.name != "Crosshair")
            {
                throw new ArgumentException(FormattableString.Invariant($"{nameof(_cursor)} is {_cursor.name}, it should be Crosshair"));
            }

            //_transform = battleFieldUi.GetComponentInChildren("UnitListUi");
        }

        public void ShowUnitListDialog()
        {
            _unitListTransform.gameObject.SetActive(true);
        }

        public void ShowUnitHealthPointsBar()
        {
            _unitHealthPoints.gameObject.SetActive(true);
        }

        internal void HideUnitHealthPointsBar()
        {
            _unitHealthPoints.gameObject.SetActive(false);
        }

        public void ShowUnitActionPointsBar()
        {
            _unitActionPoints.gameObject.SetActive(true);
        }

        internal void HideUnitActionPointsBar()
        {
            _unitActionPoints.gameObject.SetActive(false);
        }

        public void ShowEndTurnDialog()
        {
            _unitEndTurnDialog.gameObject.SetActive(true);
        }

        public void HideEndTurnDialog()
        {
            _unitEndTurnDialog.gameObject.SetActive(false);
        }

        public void ShowCrosshair()
        {
            _cursor.gameObject.SetActive(true);
        }

        public void HideCrosshair()
        {
            _cursor.gameObject.SetActive(false);
        }
    }
}
