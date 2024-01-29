
using UnityEngine;

public class ExitButton : MenuSwitchButton
{
    [SerializeField] private LevelFactory _levelFactory;
    [SerializeField] private CellBoard _cellBoard;
    [SerializeField] private GameStateMachine _gameStateMachine;

    private Level _level;

    protected override void Start()
    {
        _levelFactory.Built += (level) => _level = level;
        Button.onClick.AddListener(ClearLevel);
        Button.onClick.AddListener(_gameStateMachine.SwitchState<PauseState>);
        base.Start();

    }

    private void ClearLevel()
    {
        _level.Clear();
        _cellBoard.Clear();
    }
}
