using UnityEngine;

public class WinMenu : Menu
{
    [SerializeField] private WinState _winState;

    private void OnEnable()
    {
        _winState.Entered += Open;
        _winState.Exited += Close;
    }

    private void OnDisable()
    {
        _winState.Entered -= Open;
        _winState.Exited -= Close;
    }
}
