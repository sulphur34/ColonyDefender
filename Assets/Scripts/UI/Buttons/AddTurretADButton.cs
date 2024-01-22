using System;

public class AddTurretADButton : ADButton
{
    public event Action RewardGained;

    protected override void OnRewardGained()
    {
        RewardGained?.Invoke();
    }
}
