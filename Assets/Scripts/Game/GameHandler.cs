using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Agava.YandexGames;

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
    [SerializeField] private int _buildingTime;
    [SerializeField] private SaveHandler _saveHandler;
        
    private EnhancementSystem _enhancementSystem;
    private IFactory<Turret> _turretFactory;
    private IFactory<IWave> _waveFactory;
    private int _turretsLimit;
    private IWave _currentWave;
    private int _timeLeftToBuild;
    private Coroutine _timerCoroutine;

    public UnityEvent Lost;
    public UnityEvent Win;
    public event Action Started;
    public event Action<int> TurretAdded;
    public event Action<int> TimerChange;
    public event Action BaseBuilt;

    public int CurrentLevel => _currentLevel;
    public int MinLevelInBatch => GetMinLevelInBatch();
    public int MaxLevelInBatch => GetMaxLevelInBatch();
    public int LevelBatchValue => _levelBatchValue;
    public int TimeLeftToBuild => _timeLeftToBuild;

    private void Awake()
    {         
        _enhancementSystem = GetComponent<EnhancementSystem>();
        _turretFactory = GetComponent<TurretFactory>();
        _waveFactory = GetComponent<WaveFactory>();
        _barrier.EnemyInvaded += OnGameLost;
        _saveHandler.ProgressReseted += OnProgresReset;
        _cellBoard.Merged.AddListener(OnMerge);
        BaseBuilt += OnBaseBuilt;
        
        if (PlayerPrefs.HasKey(SaveData.ProgressLevel))
            _currentLevel = PlayerPrefs.GetInt(SaveData.ProgressLevel);
    }

    public void StartGame()
    {
        Started.Invoke();
        _timerCoroutine = StartCoroutine(InitiateBuildTimer());
        _turretsLimit = _currentLevel - _minTurretLevel + 1;
        _currentWave = _waveFactory.Build(_currentLevel);
        _currentWave.EnemiesDestroyed += OnGameWin;
        TurretAdded.Invoke(_turretsLimit);
    }

    public void OnColumnClick(int columnIndex)
    {
        if (_turretsLimit > 0 && _timeLeftToBuild > 0)
        {
            OnMerge(_minTurretLevel, columnIndex);
            _turretsLimit--;
            TurretAdded.Invoke(_turretsLimit);
        }
        
        if (_turretsLimit == 0)
            BaseBuilt?.Invoke();
    }

    private void GetSavedData()
    {
        
    }

    private void OnBaseBuilt()
    {
        StopCoroutine(_timerCoroutine);
        _currentWave.Activate();
    }

    private void OnMerge(int turretLevel, int columnIndex)
    {
        if(_cellBoard.Columns[columnIndex].TryGetFreeCell(out ICell cell))
            _cellBoard.AddTurret(cell, _turretFactory.Build(turretLevel));
    }

    private void OnGameWin()
    {
        _currentLevel++;
        PlayerPrefs.SetInt(SaveData.ProgressLevel, _currentLevel);
        PlayerPrefs.Save();
        ResetLevel();
        Win?.Invoke();        
    }

    private void OnGameLost()
    {
        ResetLevel();
        Lost?.Invoke();
    }

    private void ResetLevel()
    {
        _cellBoard.Clear();
        _currentWave.Clear();
        _currentWave.EnemiesDestroyed -= OnGameWin;
    }

    private void OnProgresReset()
    {
        _currentLevel = 1;
        _minTurretLevel = 1;
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

        while (maxLevel % _levelBatchValue != 0)
        {
            maxLevel ++;
        }

        return maxLevel;
    }

    private IEnumerator InitiateBuildTimer()
    {        
        _timeLeftToBuild = _buildingTime;
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (_timeLeftToBuild > 0)
        {
            TimerChange?.Invoke(_timeLeftToBuild);
            yield return waitForSeconds;
            _timeLeftToBuild--;            
        }

        BaseBuilt.Invoke();
    }
}
