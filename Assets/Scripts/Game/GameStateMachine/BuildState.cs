using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : GameState
{
    [SerializeField] private List<ColumnUI> _columnButtons;
    [SerializeField] private Timer _timer;

    private float _turretsLimit;
    private float _turretLevel;
    private float _buildTime;
        
    public event Action<float> TurretsAmountChanged;

    private void Awake()
    {
        foreach (var column in _columnButtons)
        {
            column.Clicked += OnColumnClick;
        }
    }    

    public override void Enter()
    {
        base.Enter();
        SetBuildParameters();
        _timer.Initialize(_buildTime);
        _timer.Begin();
        _timer.Ended += Switcher.SwitchState<DefenceState>;
    }

    private void OnColumnClick(int columnIndex)
    {
        if (_turretsLimit > 0 && _timer.TimeLeft > 0)
        {
            _cellBoard.AddTurret(columnIndex, _turretLevel);
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
        _turretLevel = _enhancementSystem.BaseTurretLevelValue;
        _buildTime = _enhancementSystem.BuiltTimeValue;
        _turretsLimit = _enhancementSystem.GameLevelValue - _turretLevel + 1;
        TurretsAmountChanged.Invoke(_turretsLimit);
    }
}
