using UnityEngine;

namespace EnhancementSystem.Enhancements
{
    public class BaseTurretLevel : Enhancement
    {
        [SerializeField] private float _upgradeRequirementStep;
        [SerializeField] private EnhancementManager _enhancementData;

        public float UpgradeRequirement => CurrentValue + _upgradeRequirementStep;

        public override bool IsAvailable()
        {
            return _enhancementData.MaxTurretLevelValue >= UpgradeRequirement;
        }
    }
}