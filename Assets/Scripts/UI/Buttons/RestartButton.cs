using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _startButton;

        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _exitButton.onClick.Invoke();
            _startButton.onClick.Invoke();
        }
    }
}