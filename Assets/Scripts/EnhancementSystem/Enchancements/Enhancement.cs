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
        Save();
        UpgradeLevel++;
        ValueChanged?.Invoke(UpgradeLevel);
    }

    public virtual void Reset()
    {
        UpgradeLevel = 0;
        SetValue(_defaultValue);
        ValueChanged?.Invoke(UpgradeLevel);
        Save();
    }

    public virtual bool IsAvailable()
    {
        return true;
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

    private void SetValue(float value)
    {
        CurrentValue = value;
    }
}
