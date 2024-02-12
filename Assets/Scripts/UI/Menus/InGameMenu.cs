using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : Menu
{
    [SerializeField] private DefenceState _defenceState;
    [SerializeField] private TrainingState _trainingState;
    [SerializeField] private BuildState _buildState;
    [SerializeField] private TurretsAmountLabel _turretsAmountLabel;
    [SerializeField] private BuildingTimerLabel _buildingTimerLabel;
    [SerializeField] private AddTurretADButton _addTurretButton;
    [SerializeField] private OffTimerADButton _offTimerButton;


    private void OnEnable()
    {
        _buildState.Entered += () => SetBuildStateUI(true);
        _trainingState.Entered += () => SetBuildStateUI(true);
        _trainingState.Entered += () => SetAllButtonsStatus(false);
        _trainingState.Exited += () => SetAllButtonsStatus(true);
        _defenceState.Entered += () => SetBuildStateUI(false);
        _defenceState.Exited += Close;
    }

    private void OnDisable()
    {
        _buildState.Entered -= () => SetBuildStateUI(true);
        _trainingState.Entered -= () => SetBuildStateUI(true);
        _trainingState.Entered -= () => SetAllButtonsStatus(false);
        _trainingState.Exited -= () => SetAllButtonsStatus(true);
        _defenceState.Entered -= () => SetBuildStateUI(false);
        _defenceState.Exited -= Close;
    }

    private void SetBuildStateUI(bool isActive)
    {
        _turretsAmountLabel.gameObject.SetActive(isActive);
        _buildingTimerLabel.gameObject.SetActive(isActive);
        _addTurretButton.gameObject.SetActive(isActive);
        _offTimerButton.gameObject.SetActive(isActive);
    }

    private void SetAllButtonsStatus(bool isActive)
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            button.enabled = isActive;
        }
    }
}
