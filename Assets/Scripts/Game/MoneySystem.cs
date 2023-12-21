using System;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] private Dictionary<string, float> _upgradesCost;
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private EnhancementSystem _enhancementSystem;
    [SerializeField] private float _moneyValue;
    [SerializeField] private float _baseLevelIncome;

    public event Action<float> AmountChanged;
    
    private void Awake()
    {
        _gameHandler.Win.AddListener(OnGameWin);
        AmountChanged.Invoke(_moneyValue);
    }

    public bool IsAffordable(float withdrawalValue)
    {
        return _moneyValue >= withdrawalValue;
    }

    private void OnGameWin()
    {
        float moneyAmount = _gameHandler.CurrentLevel * _baseLevelIncome * _enhancementSystem.CurrencyIncomeMultiplier;
        Add(moneyAmount);
    }

    private void Add(float moneyAmount)
    {
        _moneyValue += moneyAmount;
        AmountChanged.Invoke(_moneyValue);
    }

    private void Withdraw(float moneyAmount)
    {
        Add(-moneyAmount);
    }
}
