using System;
using UnityEngine;

public class ResourceSystem : MonoBehaviour, ISaveable
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

    public void Save()
    {
        PlayerPrefs.SetFloat(SaveData.AvailableResourses, _availableRecourcesValue);
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey(SaveData.AvailableResourses))
            Add(PlayerPrefs.GetFloat(SaveData.AvailableResourses));
        else
            _availableRecourcesValue = 0;
    }
}
