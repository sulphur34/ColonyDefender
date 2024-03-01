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

        public event Action<bool> MuteStatusChanged;

        public string Token => Tokens.VolumeLevel;

        public float Volume { get; private set; }
        public bool IsMuted { get; private set; }

        private void Start()
        {
            SwitchSound(GetRandomClip());
        }

        private void Update()
        {
            if (_audioSource.isPlaying == false && _isPaused == false)
                SwitchSound(GetRandomClip());
        }

        public void SetVolumeLevel(float volumeValue)
        {
            Volume = volumeValue;
            _audioSource.volume = volumeValue;
            VolumeChanged?.Invoke(volumeValue);

            if (volumeValue > 0)
                SetMuteState(false);

            Save();
        }

        public void SwitchMuteState()
        {
            SetMuteState(!IsMuted);
            SetVolumeLevel();
            Save();
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(Tokens.VolumeLevel, Volume);
            PlayerPrefs.SetInt(Tokens.IsMuted, IsMuted ? 0 : 1);
        }

        public void Load()
        {
            SetMuteState(GetMuteState());
            MuteStatusChanged?.Invoke(IsMuted);
            Volume = GetVolume();
            VolumeChanged?.Invoke(Volume);
            SetVolumeLevel();
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

            return 0.5f;
        }

        private bool GetMuteState()
        {
            if (PlayerPrefs.HasKey(Tokens.IsMuted))
                return PlayerPrefs.GetInt(Tokens.IsMuted) == 0;

            return false;
        }

        private void SetVolumeLevel()
        {
            if (IsMuted)
                _audioSource.volume = 0;
            else
                _audioSource.volume = Volume;
        }

        private void SetMuteState(bool isMuted)
        {
            IsMuted = isMuted;
            MuteStatusChanged.Invoke(IsMuted);
        }
    }
}