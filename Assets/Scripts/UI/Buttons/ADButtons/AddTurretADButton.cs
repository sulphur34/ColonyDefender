using System;
using UnityEngine;

public class AddTurretADButton : ADButton
{
    public event Action RewardGained;

    protected override void OnButtonClick()
    {
        RewardGained?.Invoke();
    }

    protected override void OnRewardGained() { }

    protected override void OnVideoClose() { }
}
