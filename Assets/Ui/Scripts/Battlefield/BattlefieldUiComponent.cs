using System;
using UnityEngine;

namespace Assets.Ui.Scripts.Battlefield
{
    public class BattlefieldUiComponent : MonoBehaviour
    {
        UnitListUiComponent _unitList;

        public static BattlefieldUiComponent Instance { get; private set; }
     
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {
            _unitList = transform.GetChild(2).GetComponent<UnitListUiComponent>();
            if (_unitList.name != "UnitListTable")
            {
                throw new ArgumentNullException("Couldn't find unit lists scroll view content.");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
