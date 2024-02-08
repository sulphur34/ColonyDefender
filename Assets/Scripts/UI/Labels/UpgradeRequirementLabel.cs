using UnityEngine;
using Lean.Localization;

public class TurretLevelRequirementLabel : CostLabel
{
    [SerializeField] private BaseTurretLevel _baseTurretLevel;
    [SerializeField] private LeanPhrase _phrase;

    private void OnEnable()
    {
        LeanLocalization.OnLocalizationChanged += SetLabelValue;
    }

    private void OnDisable()
    {
        LeanLocalization.OnLocalizationChanged -= SetLabelValue;
    }

    public override void SetLabelValue()
    {
        string prefix = LeanLocalization.GetTranslationText(_phrase.name);
        SetTextWithPrefix(prefix, _baseTurretLevel.UpgradeRequirement);
    }
}
