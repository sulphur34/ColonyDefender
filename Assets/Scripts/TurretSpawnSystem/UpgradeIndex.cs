namespace TurretSpawnSystem
{
    public class UpgradeIndex
    {
        private readonly float _maxTurretIndex;
        private readonly float _maxGradeIndex;
        private readonly float _maxGunsIndex;
        private readonly float _maxLevel;

        public UpgradeIndex(float levelIndex, float maxTurretIndex, float maxGradeIndex, float maxGunsIndex)
        {
            LevelIndex = levelIndex;
            _maxGradeIndex = maxGradeIndex;
            _maxTurretIndex = maxTurretIndex;
            _maxGunsIndex = maxGunsIndex;
            _maxLevel = _maxTurretIndex * _maxGradeIndex * _maxGunsIndex;
            SetIndexes();
        }

        public float LevelIndex { get; private set; }
        public int TurretIndex { get; private set; }
        public int GradeIndex { get; private set; }
        public int GunsIndex { get; private set; }
        public float DamageMultiplier { get; private set; }

        private void SetIndexes()
        {
            TurretIndex = 0;
            GunsIndex = 0;
            GradeIndex = 0;

            if (LevelIndex > _maxLevel)
                CountIndexes(LevelIndex % _maxLevel);
            else
                CountIndexes(LevelIndex);

            DamageMultiplier = LevelIndex / _maxGradeIndex / (GunsIndex + 1);
        }

        private void CountIndexes(float levelIndex)
        {
            for (int i = 1; i < levelIndex; i++)
            {
                if (TurretIndex < _maxTurretIndex - 1)
                {
                    TurretIndex++;
                }
                else
                {
                    TurretIndex = 0;

                    if (GradeIndex < _maxGradeIndex - 1)
                    {
                        GradeIndex++;
                    }
                    else
                    {
                        GradeIndex = 0;
                        GunsIndex++;
                    }
                }
            }
        }
    }
}