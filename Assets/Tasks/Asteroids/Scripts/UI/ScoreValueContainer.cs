using UnityEngine;
using TMPro;
using System.Collections;

namespace Asteroids
{
    public class ScoreValueContainer : PlayerStateProgressBar
    {
        [SerializeField] private TextMeshProUGUI textField;

        private const string coroutineName = "AnimateValue";

        private int numberOfDigits = 0;

        private int oldValue = 0;
        private int currentValue = 0;

        public override void UpdateValue(int value)
        {
            oldValue = currentValue;
            currentValue = value;
            //int activeValue = ((int)Mathf.Min(value, maxValue));
            //textField.SetText(string.Format($"{value}"));
            StopCoroutine(coroutineName);
            StartCoroutine(coroutineName);
        }

        public override void SetMaxValue(float maxValue)
        {
            this.maxValue = maxValue;

            // https://stackoverflow.com/questions/4483886/how-can-i-get-a-count-of-the-total-number-of-digits-in-a-number
            numberOfDigits = (int) Mathf.Floor(Mathf.Log10(maxValue) + 1);
        }

        private IEnumerator AnimateValue()
        {
            int value = oldValue;
            while(value <= currentValue)
            {
                textField.SetText(string.Format($"{value}"));
                value++;
                yield return new WaitForSeconds(0.05f);
            }
            yield return null;
        }
    }
}