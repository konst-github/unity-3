using UnityEngine;

namespace Asteroids
{
    public class PlayerStateProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        private const float height = 16;
        private const float maxWidth = 200;
        protected float maxValue = 1;

        public virtual void UpdateValue(int value)
        {
            float percent = value / maxValue;
            float width = maxWidth * percent;
            rectTransform.sizeDelta = new Vector2(width, height);
        }

        public virtual void SetMaxValue(float maxValue)
        {
            this.maxValue = maxValue;
            rectTransform.sizeDelta = new Vector2(maxWidth, height);
        }
    }
}