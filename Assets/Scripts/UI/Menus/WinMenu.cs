using UnityEngine;

public class WinMenu : Menu
{
    [SerializeField] private WinState _winState;

    private void OnEnable()
    {
        _winState.Entered += Activate;
        _winState.Exited += Deactivate;
    }

    private void OnDisable()
    {
        _winState.Entered -= Activate;
        _winState.Exited -= Deactivate;
    }
}
