using System;
using UnityEngine;

public class VideoAD : MonoBehaviour
{
    public event Action RewardGained;
    public event Action Closed;

    public void Show()
    {
        Agava.YandexGames.VideoAd.Show(OnOpenCallBack, OnRewardCallBack, OnCloseCallBack);
    }

    private void OnOpenCallBack()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnRewardCallBack()
    {
        RewardGained.Invoke();
    }

    private void OnCloseCallBack()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
        Closed.Invoke();
    }


}
