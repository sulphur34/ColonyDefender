using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ColumnUI : MonoBehaviour
    {
        [SerializeField] private int _columnNumber;

        private Button _button;

        public event Action<int> Clicked;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void SpawnTurret()
        {
            OnClick();
        }

        private void OnClick()
        {
            Clicked?.Invoke(_columnNumber);
        }
    }
}