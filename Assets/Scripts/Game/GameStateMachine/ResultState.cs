using System;
using UnityEngine;

public abstract class ResultState : GameState
{
    [SerializeField] private ResourceSystem _resourceSystem;
    [SerializeField] private LevelEndADButton _aDButton;
    [SerializeField] private SkipMultiplierButton _skipButton;

    private event Action _rewardMultiplied;

    protected RewardGenerator _rewardGenerator;

    public float Reward { get; protected set; }

    private void Start()
    {
        _rewardGenerator = new RewardGenerator(EnhancementSystem);
        _aDButton.RewardGained += MultiplyReward;
        _skipButton.Skipped += MultiplyReward;
        _rewardMultiplied += Switcher.SwitchState<PauseState>;
    }

    public override void Enter()
    {
        Reward = GenerateReward();
        base.Enter();
    }

    public override void Exit() 
    {
        base.Exit();
        _resourceSystem.Add(Reward);
    }

    protected abstract float GenerateReward();

    protected void MultiplyReward(float multiplier)
    {
        Reward *= multiplier;
        _rewardMultiplied.Invoke();
    }
}
