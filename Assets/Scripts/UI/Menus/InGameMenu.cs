
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : Menu
{
    [SerializeField] private DefenceState _defenceState;
    [SerializeField] private TrainingState _trainingState;
    [SerializeField] private BuildState _buildState;
    [SerializeField] private TurretsAmountLabel _turretsAmountLabel;
    [SerializeField] private BuildingTimerLabel _buildingTimerLabel;


    private void OnEnable()
    {
        _buildState.Entered += Open;
        _buildState.Exited += DeactivateBuildStateUI;
        _defenceState.Exited += Close;
        _trainingState.Entered += () => SetAllButtonsStatus(false);
        _trainingState.Exited += () => SetAllButtonsStatus(true);
    }

    private void OnDisable()
    {
        _buildState.Entered -= Open;
        _buildState.Exited -= DeactivateBuildStateUI;
        _defenceState.Exited -= Close;
    }

    public override void Open()
    {
        base.Open();
        _turretsAmountLabel.gameObject.SetActive(true);
        _buildingTimerLabel.gameObject.SetActive(true);
    }

    private void DeactivateBuildStateUI()
    {
        _turretsAmountLabel.gameObject.SetActive(false);
        _buildingTimerLabel.gameObject.SetActive(false);
    }

    private void SetAllButtonsStatus( bool isActive)
    {
        foreach(Button button in GetComponentsInChildren<Button>())
        {
            button.enabled = isActive;
        }
    }
}
