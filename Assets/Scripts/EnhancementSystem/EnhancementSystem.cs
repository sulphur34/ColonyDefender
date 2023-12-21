using UnityEngine;

public class EnhancementSystem : MonoBehaviour, IEnhancementSystem
{
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _damageUpgradeStep;
    [SerializeField] private float _fireRateMultiplier;
    [SerializeField] private float _fireRateUpgradeStep;
    [SerializeField] private float _timeMultiplier;
    [SerializeField] private float _timeUpgradeStep;
    [SerializeField] private float _currencyMultiplier;
    [SerializeField] private float _currencyUpgradeStep;
    [SerializeField] private float _turretLevelMultiplier;
    [SerializeField] private float _turretLevelUpgradeStep;
    [SerializeField] GameHandler _gameHandler;

    public float DamageMultiplier => _damageMultiplier;
    public float FireRateMultiplier => _fireRateMultiplier;
    public float TimeToBuildMultiplier => _timeMultiplier;
    public float CurrencyIncomeMultiplier => _currencyMultiplier;
    public float TurretLevel => _turretLevelMultiplier;
           

    public void IncreaseDamage()
    {
        IncreaseParameter(DamageMultiplier, _damageUpgradeStep);
    }

    public void IncreaseFireRate()
    {
        IncreaseParameter(FireRateMultiplier, _fireRateUpgradeStep);
    }
    public void IncreaseIncome()
    {
        IncreaseParameter(CurrencyIncomeMultiplier, _currencyUpgradeStep);
    }
    public void IncreaseBuiltTime()
    {
        IncreaseParameter(TimeToBuildMultiplier, _timeUpgradeStep);
    }

    private void IncreaseParameter(float parameter, float value)
    {
        parameter += value;
    }
    private void IncreaseParameter(int parameter, int value)
    {
        parameter += value;
    }

    private void Reset()
    {
        int defaultValue = 1;
        _damageMultiplier = defaultValue;
        _fireRateMultiplier = defaultValue;
        _currencyMultiplier= defaultValue;
        _timeMultiplier = defaultValue;
        _turretLevelMultiplier = defaultValue;
    }
}
