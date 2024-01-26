using UnityEngine;
using Lean.Localization;

public class TurretLevelRequirementLabel : CostLabel
{
    [SerializeField] private BaseTurretLevel _baseTurretLevel;

    private void Awake()
    {
        LeanLocalization.OnLocalizationChanged += SetLabelValue;
    }

    protected override void SetLabelValue()
    {
        string prefix = LeanLocalization.GetTranslationText("EnhancementMenu\\TurretLevelRequirementLabel");
        SetTextWithPrefix(prefix, _baseTurretLevel.UpgradeRequirement);
    }
}
