using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(EnhancementSystem))]
[RequireComponent(typeof(TurretFactory))]
[RequireComponent(typeof(WaveFactory))]
public class GameHandler : MonoBehaviour
{
    [SerializeField] private Barrier _barrier;
    [SerializeField] private CellBoard _cellBoard;
    [SerializeField] private int _minTurretLevel = 1;
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private int _levelBatchValue = 5;
        
    private EnhancementSystem _enhancementSystem;
    private IFactory<Turret> _turretFactory;
    private IFactory<IWave> _waveFactory;
    private int _turretsLimit;
    private IWave _currentWave;

    public UnityEvent Started;
    public UnityEvent Lost;
    public UnityEvent Win;
    public UnityEvent BaseBuilt;

    public int CurrentLevel => _currentLevel;
    public int MinLevelInBatch => GetMinLevelInBatch();
    public int MaxLevelInBatch => GetMaxLevelInBatch();

    private void Awake()
    {      
        _enhancementSystem = GetComponent<EnhancementSystem>();
        _turretFactory = GetComponent<TurretFactory>();
        _waveFactory = GetComponent<WaveFactory>();
        _barrier.EnemyInvaded += OnGameLost;
        _cellBoard.Merged.AddListener(OnMerge);
        BaseBuilt.AddListener(OnBaseBuilt);
    }

    public void StartGame()
    {
        _turretsLimit = _currentLevel - _minTurretLevel + 1;
        _currentWave = _waveFactory.Build(_currentLevel);
        _currentWave.EnemiesDestroyed += OnGameWin;
    }

    public void OnColumnClick(int columnIndex)
    {
        if (_turretsLimit > 0)
        {
            OnMerge(_minTurretLevel, columnIndex);
            _turretsLimit--;
        }
        
        if (_turretsLimit == 0)
            BaseBuilt?.Invoke();
    }

    private void OnBaseBuilt()
    {
        _currentWave.Activate();
    }

    private void OnMerge(int turretLevel, int columnIndex)
    {
        if(_cellBoard.Columns[columnIndex].TryGetFreeCell(out ICell cell))
            _cellBoard.AddTurret(cell, _turretFactory.Build(turretLevel));
    }

    private void OnGameWin()
    {
        Reset();
        Win?.Invoke();
        _currentLevel++;
    }

    private void OnGameLost()
    {
        Reset();
        Lost?.Invoke();
    }

    private void Reset()
    {
        _currentWave.EnemiesDestroyed -= OnGameWin;
        _cellBoard.Clear();
        _currentWave.Clear();
    }

    private int GetMinLevelInBatch()
    {
        return GetMaxLevelInBatch() - _levelBatchValue + 1;
    }

    private int GetMaxLevelInBatch()
    {
        int maxLevel = _currentLevel;

        while (_currentLevel % _levelBatchValue != 0)
        {
            maxLevel ++;
        }

        return maxLevel;
    }
}
