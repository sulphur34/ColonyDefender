using System;
using AudioSystem;
using UnityEngine;

namespace Utils
{
    public class VideoAD : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;

        public event Action RewardGained;
        public event Action Closed;

        public bool IsPlaying { get; private set; }

        private void Awake()
        {
            IsPlaying = false;
        }

        public void ShowRewarded()
        {
            Agava.YandexGames.VideoAd.Show(OnOpenCallBack, OnRewardCallBack, OnCloseCallBack);
        }

        public void ShowInter()
        {
            Agava.YandexGames.InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
        }

        private void OnOpenCallBack()
        {
            IsPlaying = true;
            Time.timeScale = 0;
            _audioManager.PauseClip();
        }

        private void OnRewardCallBack()
        {
            RewardGained?.Invoke();
        }

        private void OnCloseCallBack()
        {
            IsPlaying = false;
            Time.timeScale = 1;
            _audioManager.ResumeClip();
            Closed?.Invoke();
        }

        private void OnCloseCallBack(bool isShown)
        {
            OnCloseCallBack();
        }
    }
}