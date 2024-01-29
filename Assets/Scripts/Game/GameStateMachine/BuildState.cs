using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : GameState
{
    [SerializeField] private List<ColumnUI> _columnButtons;
    [SerializeField] private AddTurretADButton _addTurretButton;
    [SerializeField] private OffTimerADButton _offTimerButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyPowerUI _enemyPowerUI;

    private float _turretsLimit;
    private float _turretLevel;
    private float _buildTime;
    private IReadOnlyList<float> _routeData;
        
    public event Action<float> TurretsAmountChanged;

    private void Awake()
    {
        LevelFactory.Built += SetRouteData;
        _addTurretButton.RewardGained += OnAddTurretADGain;
        _offTimerButton.RewardGained += OnOffTimerADGain;

        foreach (var column in _columnButtons)
        {
            column.Clicked += OnColumnClick;
        }
    }    

    public override void Enter()
    {
        base.Enter();
        SetBuildParameters();
        _enemyPowerUI.Show();
        _timer.Initialize(_buildTime);
        _timer.Begin();
        _timer.Ended += Switcher.SwitchState<DefenceState>;
    }

    public override void Exit() 
    { 
        base.Exit();
        _enemyPowerUI.Hide();
        _timer.Stop();
    }

    private void OnColumnClick(int columnIndex)
    {
        if (_turretsLimit > 0 && _timer.TimeLeft > 0)
        {
            CellBoard.AddTurret(columnIndex, _turretLevel);
            _turretsLimit--;
            TurretsAmountChanged.Invoke(_turretsLimit);
        }

        if (_turretsLimit == 0)
        {
            _timer.Ended -= Switcher.SwitchState<DefenceState>;
            _timer.Stop();
            Switcher.SwitchState<DefenceState>();
        }
    }

    private void SetBuildParameters()
    {
        _turretLevel = EnhancementSystem.BaseTurretLevelValue;
        _buildTime = EnhancementSystem.BuiltTimeValue;
        _turretsLimit = EnhancementSystem.GameLevelValue - _turretLevel + 1;
        TurretsAmountChanged.Invoke(_turretsLimit);
    }

    private void SetRouteData(Level level)
    {
        _routeData = level.Wave.RouteData;
    }

    private void OnAddTurretADGain()
    {
        _turretsLimit++;
    }

    private void OnOffTimerADGain()
    {
        _timer.Pause();
    }
}
