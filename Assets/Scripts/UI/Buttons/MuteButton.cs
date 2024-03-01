using AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class MuteButton : MonoBehaviour
    {
        [SerializeField] private Image _muteIcon;
        [SerializeField] private Image _unmuteIcon;
        [SerializeField] private AudioManager _audioManager;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            _audioManager.MuteStatusChanged += OnMuteStatusChange;
        }

        private void OnEnable()
        {
            OnMuteStatusChange(_audioManager.IsMuted);
        }

        private void OnDestroy()
        {
            _audioManager.MuteStatusChanged -= OnMuteStatusChange;
        }

        private void OnMuteStatusChange(bool isMuted)
        {
            _muteIcon.enabled = isMuted;
            _unmuteIcon.enabled = !isMuted;
        }

        private void OnClick()
        {
            _audioManager.SwitchMuteState();
        }
    }
}