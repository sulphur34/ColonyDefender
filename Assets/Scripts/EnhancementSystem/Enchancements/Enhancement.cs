using System;
using UnityEngine;

public class Enhancement : MonoBehaviour, ISaveable
{
    [SerializeField] private float _defaultValue;
    [SerializeField] private float _upgradeStep;

    protected string SaveToken;

    public event Action<float> ValueChanged;

    public float CurrentValue { get; private set; }

    public float UpgradeLevel { get; private set; }

    public virtual void Increase()
    {
        SetValue(CurrentValue += _upgradeStep);
        UpgradeLevel++;
        ValueChanged?.Invoke(UpgradeLevel);
    }

    public virtual void Reset()
    {
        UpgradeLevel = 0;
        SetValue(_defaultValue);
        ValueChanged?.Invoke(UpgradeLevel);
    }

    public virtual bool IsAvailable()
    {
        return true;
    }

    protected void SetValue(float value)
    {
        CurrentValue = value;
    }

    public virtual void Save()
    {
        PlayerPrefs.SetFloat(SaveToken, CurrentValue);
    }

    public virtual void Load()
    {
        if (PlayerPrefs.HasKey(SaveToken))
        {
            CurrentValue = PlayerPrefs.GetFloat(SaveToken);
            UpgradeLevel = Mathf.Round((CurrentValue - _defaultValue) / _upgradeStep);
            ValueChanged?.Invoke(UpgradeLevel);
        }
        else
            Reset();
    }
}
