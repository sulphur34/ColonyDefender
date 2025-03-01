using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Buttons.ADButtons
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(VideoAD))]
    public abstract class ADRewardedButton : ADButton
    {
        protected override void Awake()
        {
            base.Awake();
            VideoAD.RewardGained += OnRewardGained;
        }

        protected override void ShowAD()
        {
            VideoAD.ShowRewarded();
        }

        protected abstract void OnRewardGained();
    }
}