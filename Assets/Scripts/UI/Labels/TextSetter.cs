using TMPro;
using UnityEngine;

namespace UI.Labels
{
    public class TextSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = _label.GetComponent<RectTransform>();
        }

        public void Show()
        {
            _label.enabled = true;
        }

        public void Hide()
        {
            _label.enabled = false;
        }

        protected void SetText(int amount)
        {
            _label.text = amount.ToString();
        }

        protected void SetText(float amount)
        {
            _label.text = amount.ToString();
        }

        protected void SetText(string message)
        {
            _label.text = message;
        }

        protected void SetTextWithPrefix(string prefix, float amount)
        {
            string message = prefix + amount.ToString();
            SetText(message);
        }

        protected void SetColor(Color color)
        {
            _label.color = color;
        }

        protected void ResizeText()
        {
            float preferredWidth = _label.preferredWidth;
            float preferredHeight = _label.preferredHeight;

            _rectTransform.sizeDelta = new Vector2(preferredWidth, preferredHeight);
        }
    }
}