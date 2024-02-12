using Agava.WebUtility;
using UnityEngine;

public class TestFocus : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

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
        _audioSource.volume = value ? 0f : 1f;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0f : 1f;
    }
}
