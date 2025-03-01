using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class PurchaseButton : MonoBehaviour
    {
        private Purchase _purchase;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void Initialize(Purchase purchase)
        {
            _purchase = purchase;
        }

        public void Enable()
        {
            _button.interactable = true;
        }

        public void Disable()
        {
            _button.interactable = false;
        }

        private void OnClick()
        {
            _purchase.TryBuy();
        }
    }
}