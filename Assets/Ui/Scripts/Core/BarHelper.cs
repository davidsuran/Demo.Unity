using UnityEngine;
using UnityEngine.UI;

namespace Assets.Ui.Scripts.Core
{
    internal static class BarHelper
    {
        internal static void UpdateMask(float currentValue, float maxValue,
            float baseWidth, float offset, float scale,
            RectMask2D mask, RectTransform image)
        {
            maxValue = maxValue * scale;
            currentValue = currentValue * scale;

            float imageWidth = baseWidth + ((baseWidth / 200f) * (maxValue - (100f)));

            mask.rectTransform.position = new Vector3(
                ((imageWidth / 2f) * scale) + offset,
                image.transform.position.y, 0f);

            image.anchoredPosition = new Vector2((imageWidth / 2f), image.anchoredPosition.y);
            image.sizeDelta = new Vector2(imageWidth, image.sizeDelta.y);

            mask.rectTransform.sizeDelta = image.sizeDelta;

            mask.padding = new Vector4(
                mask.padding.x,
                mask.padding.y,
                (imageWidth - ((currentValue / maxValue) * imageWidth)) * scale,
                mask.padding.w);
        }
    }
}
