using System;
using System.Collections.Generic;
using UI.Buttons;
using UI.Buttons.ADButtons;
using UI.EnemyPowerUI;
using UnityEngine;
using Utils;

namespace GameSystem.GameStateMachineSystem
{
    public class BuildState : GameState
    {
        [SerializeField] protected Timer TimerInstance;
        [SerializeField] private List<ColumnUI> _columnButtons;
        [SerializeField] private AddTurretADButton _addTurretButton;
        [SerializeField] private OffTimerADButton _offTimerButton;
        [SerializeField] private EnemyPowerPanel _enemyPowerUI;

        private float _turretsLimit;
        private float _turretLevel;
        private float _buildTime;

        public event Action<float> TurretsAmountChanged;

        private void Awake()
        {
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
            TimerInstance.Initialize(_buildTime);
            TimerInstance.Reset();
            TimerInstance.Begin();
            TimerInstance.Ended += Switcher.SwitchState<DefenseState>;
            _addTurretButton.gameObject.SetActive(true);
            _offTimerButton.gameObject.SetActive(true);
            SetUIColumnStatus(true);
        }

        public override void Exit()
        {
            base.Exit();
            SetUIColumnStatus(false);
            _enemyPowerUI.Hide();
            TimerInstance.Pause();
            _addTurretButton.gameObject.SetActive(false);
            _offTimerButton.gameObject.SetActive(false);
        }

        private void OnColumnClick(int columnIndex)
        {
            if (_turretsLimit > 0 && TimerInstance.TimeLeft > 0)
            {
                CellBoard.AddTurret(columnIndex, _turretLevel);
                _turretsLimit--;
                TurretsAmountChanged?.Invoke(_turretsLimit);
            }

            if (_turretsLimit == 0)
            {
                TimerInstance.Ended -= Switcher.SwitchState<DefenseState>;
                TimerInstance.Stop();
                Switcher.SwitchState<DefenseState>();
            }
        }

        private void SetBuildParameters()
        {
            _turretLevel = EnhancementSystem.BaseTurretLevelValue;
            _buildTime = EnhancementSystem.BuiltTimeValue;
            _turretsLimit = EnhancementSystem.GameLevelValue - _turretLevel + 1;
            TurretsAmountChanged?.Invoke(_turretsLimit);
        }

        private void OnAddTurretADGain()
        {
            _turretsLimit++;
            TurretsAmountChanged?.Invoke(_turretsLimit);
        }

        private void OnOffTimerADGain()
        {
            TimerInstance.Pause();
        }

        private void SetUIColumnStatus(bool isActive)
        {
            foreach (ColumnUI button in _columnButtons)
            {
                button.gameObject.SetActive(isActive);
            }
        }
    }
}