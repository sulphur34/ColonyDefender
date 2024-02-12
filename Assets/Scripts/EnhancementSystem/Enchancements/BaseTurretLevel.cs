using UnityEngine;

public class BaseTurretLevel : Enhancement
{
    [SerializeField] private float _upgradeRequirementStep;
    [SerializeField] private EnhancementSystem _enhancementData;
    
    public float UpgradeRequirement => CurrentValue + _upgradeRequirementStep;

    private void Awake()
    {
        SaveToken = SaveData.BaseTurretLevel;
    }

    public override bool IsAvailable()
    {
        return _enhancementData.MaxTurretLevelValue >= UpgradeRequirement;
    }
}
