using UnityEngine;

namespace WaveSystem
{
    public class WaveData
    {
        private readonly int _stageIndex = 5;
        private float _levelIndex;
        private float _enemyPool;
        private float _startEnemyPool = 9;

        public WaveData(float levelIndex)
        {
            _levelIndex = levelIndex;
            _enemyPool = levelIndex + _startEnemyPool;
            Initialize();
            GenerateEnemiesData();
        }

        public float SmallEnemyMultiplier { get; private set; }
        public float MediumEnemyMultiplier { get; private set; }
        public float LargeEnemyMultiplier { get; private set; }
        public float SmallEnemyAmount { get; private set; }
        public float MediumEnemyAmount { get; private set; }
        public float LargeEnemyAmount { get; private set; }
        public bool IsBossLevel { get; private set; }

        private void Initialize()
        {
            SmallEnemyMultiplier = 1;
            MediumEnemyMultiplier = 4;
            LargeEnemyMultiplier = 9;
            SmallEnemyAmount = 0;
            MediumEnemyAmount = 0;
            LargeEnemyAmount = 0;
        }

        private void GenerateEnemiesData()
        {
            float enemiesPool = _enemyPool;

            if (_levelIndex % _stageIndex == 0)
            {
                IsBossLevel = true;
                return;
            }

            while (enemiesPool > 0)
            {
                if (CanAddEnemy(enemiesPool, LargeEnemyMultiplier))
                {
                    enemiesPool -= LargeEnemyMultiplier;
                    LargeEnemyAmount++;
                }
                else if (CanAddEnemy(enemiesPool, MediumEnemyMultiplier))
                {
                    enemiesPool -= MediumEnemyMultiplier;
                    MediumEnemyAmount++;
                }
                else
                {
                    SmallEnemyAmount = enemiesPool;
                    enemiesPool = 0;
                }
            }
        }

        private bool CanAddEnemy(float poolValue, float enemieMultiplier)
        {
            float percentageMultiplier = 100;
            float probability = (1 - enemieMultiplier / poolValue) * percentageMultiplier;
            return Random.Range(0, percentageMultiplier) <= probability;
        }
    }
}