using Assets.Scripts.Core.StateMachines.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class InputReaderComponent : MonoBehaviour
    {
        public InputReaderStateMachine InputReaderStateMachine { get => InputReaderStateMachine.Instance; }

        public string CurrentStateString;

        private void OnEnable()
        {
            InputReaderStateMachine.OnEnable();
        }

        private void Update()
        {
            InputReaderStateMachine.Update();
            CurrentStateString = InputReaderStateMachine.CurrentStateString;
        }
    }
}
