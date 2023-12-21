
public interface IEnhancementSystem
{
    public float DamageMultiplier { get; }
    public float FireRateMultiplier { get; }
    public float TimeToBuildMultiplier { get; }
    public float CurrencyIncomeMultiplier { get; }
    public float TurretLevel { get; }

    void IncreaseDamage();
    void IncreaseFireRate();
    void IncreaseIncome();
    void IncreaseBuiltTime();
}
