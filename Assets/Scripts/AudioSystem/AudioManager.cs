using System;
using SaveSystem;
using UnityEngine;
using Utils.Interfaces;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour, ISavable
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _clips;

        private bool _isPaused = false;

        public event Action<float> VolumeChanged;

        public string Token => Tokens.VolumeLevel;

        public float Volume => GetVolume();

        private void Start()
        {
            SwitchSound(GetRandomClip());
        }

        private void Update()
        {
            if (_audioSource.isPlaying == false && _isPaused == false)
            {
                SwitchSound(GetRandomClip());
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
            PlayerPrefs.SetFloat(Tokens.VolumeLevel, _audioSource.volume);
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

        private void SwitchSound(AudioClip audioClip)
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
            if (PlayerPrefs.HasKey(Tokens.VolumeLevel))
                return PlayerPrefs.GetFloat(Tokens.VolumeLevel);
            else
                return 0.5f;
        }
    }
}