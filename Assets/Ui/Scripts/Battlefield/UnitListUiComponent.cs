using Assets.Scripts.Core.Providers;
using Demo.Data;
using Demo.Data.ObserverArguments;
using Demo.Data.Units;
using System;
using TMPro;
using UnityEngine;
using static Assets.Ui.Scripts.Battlefield.ButtonUiComponent;

namespace Assets.Ui.Scripts.Battlefield
{
    public class UnitListUiComponent : MonoBehaviour, IObserver<UnitListArguments>
    {
        Transform _scrollViewContent;
        Transform _canvas;
        GameObject _cellPrefab;

        private const int UNIT_LIST_CELL_ID = 1;

        private void Awake()
        {
            _canvas = transform.GetChild(0);
            _scrollViewContent = _canvas.GetChild(0).GetChild(0).GetChild(0).GetChild(0);
            if (_scrollViewContent.name != "Content")
            {
                throw new ArgumentNullException("Couldn't find unit lists scroll view content.");
            }

            _cellPrefab = ResourceLoader.LoadUi(UNIT_LIST_CELL_ID);

            IDisposable x = BattlefieldProvider.Instance.SubscribeToBattlefield(this);
            _canvas.gameObject.SetActive(false);
        }

        private void Start()
        {
        }

        private void OnEnable()
        {
            //IDisposable x = BattlefieldExposer.Instance.SubscribeToBattlefield(this);
        }

        private void OnDisable()
        {
            //BattlefieldExposer.Instance.SubscribeToBattlefield(this);
        }

        /// <summary>
        /// Called when [completed].
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void OnCompleted()
        {
            // disable
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        /// <param name="error">The error.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [next].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void OnNext(UnitListArguments args)
        {
            if (args != null && _cellPrefab != null)
            {
                if (args.Soldiers != null || args.Drones != null)
                {
                    _canvas.gameObject.SetActive(true);

                    // TODO: reuse
                    for (int i = 0; i < _scrollViewContent.childCount; i++)
                    {
                        GameObject oldCell = _scrollViewContent.GetChild(i).gameObject;
                        //_oldCell.SetActive(false);
                        Destroy(oldCell);
                    }

                    TextMeshProUGUI cellText = _cellPrefab.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

                    foreach (Soldier soldier in args.Soldiers)
                    {
                        cellText.text = FormattableString.Invariant($"{soldier.Name},HP:{soldier.Stats?.HealthPoints}");
                        
                        GameObject cell = Instantiate(_cellPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        cell.transform.SetParent(_scrollViewContent);

                        ButtonUiComponent button = cell.transform.GetChild(0).GetComponent<ButtonUiComponent>();
                        button.CustomTag = soldier.Name;
                        //TODO: unsubscribe
                        button.ButtonPressEventHandler += SwitchToSelectedPlayer;
                    }
                }
            }
        }

        /// <summary>
        /// Switchs to selected player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ButtonUiComponentEventArgs"/> instance containing the event data.</param>
        private void SwitchToSelectedPlayer(object sender, ButtonUiComponentEventArgs args)
        {
            Debug.Log(args.Text + ", " + args.CustomTag);

            transform.gameObject.SetActive(false);

            BattlefieldProvider.Instance.UnitSelected(args.CustomTag);
        }
    }
}
