using EnhancementSystem;
using UnityEngine;

namespace GameSystem
{
    public class RewardGenerator
    {
        private float _baseLevelIncomeValue = 10;
        private float _minRatio = 0.8f;
        private float _maxRatio = 1.1f;
        private float _looseDownGrade = 0.6f;
        private EnhancementManager _enhancementSystem;

        public RewardGenerator(EnhancementManager enhancementSystem)
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

        private float GetRandomRatio()
        {
            return Random.Range(_minRatio, _maxRatio);
        }
    }
}
