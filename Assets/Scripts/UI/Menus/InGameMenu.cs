
using UnityEngine;

public class InGameMenu : Menu
{
    [SerializeField] private DefenceState _defenceState;
    [SerializeField] private BuildState _buildState;
    [SerializeField] private TurretsAmountLabel _turretsAmountLabel;
    [SerializeField] private BuildingTimerLabel _buildingTimerLabel;


    private void OnEnable()
    {
        _buildState.Entered += Activate;
        _defenceState.Exited += Deactivate;
    }

    private void OnDisable()
    {
        _buildState.Entered -= Activate;
        _defenceState.Exited -= Deactivate;
    }

    public override void Activate()
    {
        base.Activate();
        _turretsAmountLabel.gameObject.SetActive(true);
        _buildingTimerLabel.gameObject.SetActive(true);
    }
}
