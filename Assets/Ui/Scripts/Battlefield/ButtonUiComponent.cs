using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Ui.Scripts.Battlefield
{
    public class ButtonUiComponent : MonoBehaviour
    {
        public class ButtonUiComponentEventArgs : EventArgs
        {
            public string Text { get; set; }

            public string CustomTag { get; set; }
        }

        public event EventHandler<ButtonUiComponentEventArgs> ButtonPressEventHandler;

        public EventArgs ButtonPressArgs;

        public string CustomTag { get; set; }

        public void OnButtonPressed(Button button)
        {
            string cellText = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            ButtonPressEventHandler?.Invoke(this, new ButtonUiComponentEventArgs
            {
                CustomTag = this.CustomTag,
                Text = cellText
            });
        }
    }
}
