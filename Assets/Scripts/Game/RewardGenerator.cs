using UnityEngine;

public class RewardGenerator
{
    private float _enhancementRatio;
    private float _levelValue;
    private float _baseLevelIncomeValue = 10;
    private float _advertIncomeValue = 2000;
    private float _advertUpgradeThreshold = 10;
    private float _minRatio = 0.8f;
    private float _maxRatio = 1.1f;
    private float _looseDownGrade = 0.6f;
    private EnhancementSystem _enhancementSystem;

    public RewardGenerator(EnhancementSystem enhancementSystem)
    {
        _enhancementSystem = enhancementSystem;
    }

    public float GetLevelWinReward()
    {
        float reward = _baseLevelIncomeValue * _enhancementSystem.GameLevelValue;
        float randomMultiplier = GetRandomRatio();
        float multiplier = randomMultiplier * _enhancementSystem.ResourcesIncomeValue;
        return Mathf.Round(reward * multiplier);
    }

    public float GetLevelLooseReward()
    {
        float reward = GetLevelWinReward();
        return Mathf.Round(reward * _looseDownGrade);
    }

    public float GetAdvertReward()
    {
        float reward = _advertIncomeValue + _advertIncomeValue * 
            Mathf.Round(_enhancementSystem.GameLevelValue / _advertUpgradeThreshold);
        return Mathf.Round(reward);
    }

    private float GetRandomRatio()
    {
        return Random.Range(_minRatio, _maxRatio);
    }
}
