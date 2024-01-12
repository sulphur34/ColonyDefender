using System;
using UnityEngine;

public class Enhancement : MonoBehaviour
{
    [SerializeField] private float _defaultValue;
    [SerializeField] private float _upgradeStep;
    
    public event Action<float> ValueChanged;

    public float CurrentValue { get; private set; }
    
    public float UpgradeLevel { get; private set; }  

    private void Awake()
    {
        Reset();
    }

    public virtual void Increase()
    {
        SetValue(CurrentValue += _upgradeStep);
        UpgradeLevel ++;
    }

    public virtual void Reset()
    {
        UpgradeLevel = 0;
        SetValue(_defaultValue);
    }

    private void SetValue(float value)
    {
        CurrentValue = value;
        ValueChanged?.Invoke(UpgradeLevel);
    }

    public virtual bool IsAvailable()
    {
        return true;
    }
}
