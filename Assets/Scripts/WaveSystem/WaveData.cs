public class WaveData
{
    private int _waveSize;
    private readonly int _stageIndex = 5;
    private readonly float _defaultHealth;

    public WaveData(float level, int maxCapacity, int modelsAmount, float defaultHealth)
    {
        _defaultHealth = defaultHealth;
        Initialize(level, maxCapacity, modelsAmount);
    }

    public int SmallEnemyMultiplier { get; private set; }
    public int MediumEnemyMultiplier { get; private set; }
    public int LargeEnemyMultiplier { get; private set; }
    public float SmallEnemyHealth => SmallEnemyMultiplier * _defaultHealth;
    public float MediumEnemyHealth => MediumEnemyMultiplier * _defaultHealth;
    public float LargeEnemyHealth => LargeEnemyMultiplier * _defaultHealth;
    public float BossHealth => _waveSize * _defaultHealth;
    public int SmallEnemyAmount { get; private set; }
    public int MediumEnemyAmount { get; private set; }
    public int LargeEnemyAmount { get; private set; }
    public bool IsBossLevel { get; private set; }
    public int ModelIndex { get; private set; }
    public float LevelExceedMultiplier { get; private set; }

    private void Initialize(float level, int maxCapacity, int modelsAmount)
    {
        SmallEnemyMultiplier = 1;
        MediumEnemyMultiplier = 4;
        LargeEnemyMultiplier = 9;
        ModelIndex = (((int)level - 1) % (modelsAmount * _stageIndex)) / _stageIndex;

        if (level > maxCapacity)
        {
            LevelExceedMultiplier = level / maxCapacity + 1;
            _waveSize = (int)level % maxCapacity;
        }
        else
        {
            LevelExceedMultiplier = 1;
            _waveSize = (int)level;
        }

        if (_waveSize % _stageIndex == 0)
            IsBossLevel = true;
        else
            SetAmount();

    }

    private void SetAmount()
    {
        LargeEnemyAmount = GetEnemyAmount(LargeEnemyMultiplier);
        MediumEnemyAmount = GetEnemyAmount(MediumEnemyMultiplier);
        SmallEnemyAmount = GetEnemyAmount(SmallEnemyMultiplier);
    }

    private int GetEnemyAmount(int size)
    {
       int amount = 0;

        while (_waveSize >= size)
        {
            amount++;
            _waveSize -= size;
        }

        return amount;
    }
}
