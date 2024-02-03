using System;

public class OffTimerADButton : ADButton
{
    public event Action RewardGained;

    protected override void OnButtonClick()
    {
        RewardGained?.Invoke();
    }

    protected override void OnRewardGained() { }

    protected override void OnVideoClose() { }
}
