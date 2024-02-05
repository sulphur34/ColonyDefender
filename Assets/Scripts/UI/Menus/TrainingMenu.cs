using UnityEngine;

public class TrainingMenu : Menu
{
    [SerializeField] private ExplanationPanel _firstExplanationPanel;
    [SerializeField] private ExplanationPanel _lastExplanationPanel;

    public override void Open()
    {
        base.Open();
        _firstExplanationPanel.Open();
        _lastExplanationPanel.Closed += Close;
    }
}
