using System;
using UnityEngine;

public class AudioManager : MonoBehaviour, ISaveable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;

    private bool _isPaused = false;

    public event Action<float> VolumeChanged;

    public float Volume => GetVolume();

    private void Start()
    {
        SwichSound(GetRandomClip());
    }

    private void Update()
    {
        if (_audioSource.isPlaying == false && _isPaused == false)
        {
            SwichSound(GetRandomClip());
        }
    }

    public void SetVolumeLevel(float volumeValue)
    {
        _audioSource.volume = volumeValue;
        VolumeChanged?.Invoke(volumeValue);
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(SaveData.VolumeLevel, _audioSource.volume);
    }

    public void Load()
    {
        _audioSource.volume = GetVolume();
    }

    public void PauseClip()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Pause();
            _isPaused = true;
        }
    }

    public void ResumeClip()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
            _isPaused = false;
        }
    }

    private void SwichSound(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        ResumeClip();
    }

    private AudioClip GetRandomClip()
    {
        int clipIndex = UnityEngine.Random.Range(0, _clips.Length);
        return _clips[clipIndex];
    }

    private float GetVolume()
    {
        if (PlayerPrefs.HasKey(SaveData.VolumeLevel))
            return PlayerPrefs.GetFloat(SaveData.VolumeLevel);
        else
            return 0.5f;
    }
}
