using UnityEngine;

public class StartButton : MenuSwitchButton
{
    [SerializeField] private GameStateMachine _gameStateMachine;
        
    protected override void Start()
    {
        base.Start();
        Button.onClick.AddListener(_gameStateMachine.SwitchState<BuildState>);        
    }
}
