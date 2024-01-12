using UnityEngine;

public class TurretLevelRequirementLabel : CostLabel
{
    [SerializeField] private BaseTurretLevel _baseTurretLevel;
    [SerializeField] private string _prefix;

    protected override void SetLabelValue()
    {
        SetTextWithPrefix(_prefix, _baseTurretLevel.UpgradeRequirement);
    }
}
