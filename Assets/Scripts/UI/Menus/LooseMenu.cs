using UnityEngine;

public class LooseMenu : Menu
{
    [SerializeField] private LooseState _looseState;

    private void OnEnable()
    {
        _looseState.Entered += Activate;
        _looseState.Exited += Deactivate;
    }

    private void OnDisable()
    {
        _looseState.Entered -= Activate;
        _looseState.Exited -= Deactivate;
    }
}
