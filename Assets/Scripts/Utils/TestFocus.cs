using Agava.WebUtility;
using AudioSystem;
using UnityEngine;

namespace Utils
{
    public class TestFocus : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private VideoAD[] _videoADs;

        private void OnEnable()
        {
            Application.focusChanged += OnBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent += OnBackgroundChangeWeb;
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent -= OnBackgroundChangeWeb;
        }

        private void OnBackgroundChangeApp(bool inApp)
        {
            MuteAudio(!inApp);
            PauseGame(!inApp);
        }

        private void OnBackgroundChangeWeb(bool isBackground)
        {
            MuteAudio(isBackground);
            PauseGame(isBackground);
        }

        private void MuteAudio(bool value)
        {
            if (value)
            {
                _audioManager.PauseClip();
            }
            else
            {
                if (IsADPlaying() == false)
                {
                    _audioManager.ResumeClip();
                }
            }
        }

        private void PauseGame(bool value)
        {
            if (value)
            {
                Time.timeScale = 0f;
            }
            else
            {
                if (IsADPlaying() == false)
                {
                    Time.timeScale = 1f;
                }
            }
        }

        private bool IsADPlaying()
        {
            foreach (VideoAD videoAD in _videoADs)
            {
                if (videoAD.IsPlaying)
                    return true;
            }

            return false;
        }
    }
}