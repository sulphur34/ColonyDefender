using System;

public class OffTimerADButton : ADButton
{
    public event Action RewardGained;

    protected override void OnRewardGained()
    {
        RewardGained?.Invoke();
    }
}
