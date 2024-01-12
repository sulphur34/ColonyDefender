using System;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    [SerializeField] private float _availableRecourcesValue;

    public event Action<float> AmountChanged;

    public float AvailableResources => _availableRecourcesValue;
    
    private void Awake()
    {
        AmountChanged.Invoke(_availableRecourcesValue);
    }

    public void Withdraw(Purchase purchase)
    {
        _availableRecourcesValue -= purchase.CurrentCost;
        AmountChanged.Invoke(_availableRecourcesValue);
    }

    public bool IsAffordable(float withdrawalValue)
    {
        return _availableRecourcesValue >= withdrawalValue;
    }

    public void Add(float rewardValue)
    {
        _availableRecourcesValue += rewardValue;
        AmountChanged.Invoke(_availableRecourcesValue);
    }
}
