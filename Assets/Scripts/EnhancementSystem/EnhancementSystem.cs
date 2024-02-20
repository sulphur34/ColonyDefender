using System;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementSystem : MonoBehaviour, ISaveable
{
    [SerializeField] private Dictionary<Type, Enhancement> _enchancements;
    [SerializeField] private float _levelBatchValue = 5;

    public float FireRateValue => Get<FireRate>().CurrentValue;
    public float DamageValue => Get<Damage>().CurrentValue;
    public float ResourcesIncomeValue => Get<ResourceIncome>().CurrentValue * GameLevelValue;
    public float BuiltTimeValue => Get<BuildTime>().CurrentValue;
    public float BaseTurretLevelValue => Get<BaseTurretLevel>().CurrentValue;
    public float GameLevelValue => Get<GameLevel>().CurrentValue;
    public float LevelBatchValue => _levelBatchValue;
    public float MaxTurretLevelValue { get; private set; }

    public void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _enchancements = new Dictionary<Type, Enhancement>();

        foreach (var enhancement in GetComponents<Enhancement>())
        {
            _enchancements.Add(enhancement.GetType(), enhancement);
        }
    }

    public void Reset()
    {
        foreach (KeyValuePair<Type, Enhancement> enhancement in _enchancements)
        {
            enhancement.Value.Reset();
        }
    }

    private Enhancement Get<T>() where T : Enhancement
    {
        return _enchancements.TryGetValue(typeof(T), out Enhancement enhancement) ? enhancement : null;
    }

    public void Upgrade<T>() where T : Enhancement
    {
        Enhancement enhancement = Get<T>();
        enhancement?.Increase();
    }

    public void SetMaxTurretLevel(CellBoard cellBoard)
    {
        MaxTurretLevelValue = cellBoard.MaxTurretLevel;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(SaveData.MaxTurretBuilt, MaxTurretLevelValue);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(SaveData.MaxTurretBuilt))
            MaxTurretLevelValue = PlayerPrefs.GetFloat(SaveData.MaxTurretBuilt);
        else
            MaxTurretLevelValue = 0;
    }
}
