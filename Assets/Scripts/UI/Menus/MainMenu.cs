using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private PauseState _pauseState;
    [SerializeField] private LevelProgressUI _levelProgressUI;

    private void OnEnable()
    {
        _pauseState.Entered += Open;
        _pauseState.Exited += Close;
    }

    private void OnDisable()
    {
        _pauseState.Entered -= Open;
        _pauseState.Exited -= Close;
    }

    public override void Open()
    {
        base.Open();
        _levelProgressUI.Reset();
    }
}
