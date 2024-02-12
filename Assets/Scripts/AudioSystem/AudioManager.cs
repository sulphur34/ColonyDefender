using System;
using UnityEngine;

public class AudioManager : MonoBehaviour, ISaveable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;

    public event Action<float> VolumeChanged;

    public float Volume => _audioSource.volume;

    private void Update()
    {
        if (_audioSource.isPlaying == false)
        {
            SwichSound(GetRandomClip());
        }
    }

    public void SetVolumeLevel(float volumeValue)
    {
        _audioSource.volume = volumeValue;
        VolumeChanged?.Invoke(volumeValue);
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

    private void SwichSound(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private AudioClip GetRandomClip()
    {
        int clipIndex = UnityEngine.Random.Range(0, _clips.Length);
        return _clips[clipIndex];
    }
}
