using UnityEngine;

public class StartButton : MenuSwitchButton
{
    public const float TrainingLevelsValue = 2;

    [SerializeField] private GameStateMachine _gameStateMachine;
    [SerializeField] private EnhancementSystem _enhancementSystem;

        
    protected override void Start()
    {
        base.Start();
        Button.onClick.AddListener(StartGame);        
    }

    private void StartGame()
    {
        if (_enhancementSystem.GameLevelValue <= TrainingLevelsValue)
            _gameStateMachine.SwitchState<TrainingState>();
        else
            _gameStateMachine.SwitchState<BuildState>();
    }
}
