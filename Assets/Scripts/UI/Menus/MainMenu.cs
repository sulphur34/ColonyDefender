using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private PauseState _pauseState;
    [SerializeField] private LevelProgressUI _levelProgressUI;

    private void OnEnable()
    {
        _pauseState.Entered += Activate;
        _pauseState.Exited += Deactivate;
    }

    private void OnDisable()
    {
        _pauseState.Entered -= Activate;
        _pauseState.Exited -= Deactivate;
    }

    public override void Activate()
    {
        base.Activate();
        _levelProgressUI.Reset();
    }
}
