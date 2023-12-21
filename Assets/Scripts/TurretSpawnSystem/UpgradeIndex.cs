public class UpgradeIndex 
{
    private readonly int _maxTurretIndex;
    private readonly int _maxGradeIndex;
    private readonly int _maxGunsIndex;
    private readonly int _maxLevel;

    public UpgradeIndex(int levelIndex, int maxTurretIndex, int maxGradeIndex, int maxGunsIndex)
    {
        LevelIndex = levelIndex;
        _maxGradeIndex = maxGradeIndex;
        _maxTurretIndex = maxTurretIndex;
        _maxGunsIndex = maxGunsIndex;
        _maxLevel = _maxTurretIndex * _maxGradeIndex * _maxGunsIndex;
        SetIndexes();
    }

    public int LevelIndex { get; private set; }
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
            CountIndexes(LevelIndex - _maxLevel);
        else
            CountIndexes(LevelIndex);

        DamageMultiplier = (float)LevelIndex / (float)_maxGradeIndex / ((float)GunsIndex + 1);
    }

    private void CountIndexes(int levelIndex) 
    {
        for (int i = 1; i < levelIndex; i++)
        {
            if(TurretIndex < _maxTurretIndex - 1)
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
                };
            }
        }
    }    
}