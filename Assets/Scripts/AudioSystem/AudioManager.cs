using System;
using UnityEngine;

public class AudioManager : MonoBehaviour, ISaveable
{
    [SerializeField] private PauseState _pauseState;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _menuSound;
    [SerializeField] private AudioClip _actionSound;

    public event Action<float> VolumeChanged;

    public float Volume => _audioSource.volume;

    private void Awake()
    {
        _pauseState.Entered += PlayMenuSound;
        _pauseState.Exited += PlayActionSound;
    }

    private void Start()
    {
        _audioSource.clip = _menuSound;
    }

    public void SetVolumeLevel(float volumeValue)
    {
        _audioSource.volume = volumeValue;
        VolumeChanged?.Invoke(volumeValue);
    }

    private void SwichSound(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private void PlayMenuSound()
    {
        SwichSound(_menuSound);
    }

    private void PlayActionSound()
    {
        SwichSound(_actionSound);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(SaveData.VolumeLevel, _audioSource.volume);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(SaveData.VolumeLevel))
            _audioSource.volume = PlayerPrefs.GetFloat(SaveData.VolumeLevel);
        else
            _audioSource.volume = 0.5f;
    }
}
