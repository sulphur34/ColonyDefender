using System;
using GameSystem.GameStateMachineSystem;
using UI.Buttons.ADButtons;
using UI.Labels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus
{
    public class InGameMenu : Menu
    {
        [SerializeField] private DefenseState _defenseState;
        [SerializeField] private TrainingState _trainingState;
        [SerializeField] private BuildState _buildState;
        [SerializeField] private TurretsAmountLabel _turretsAmountLabel;
        [SerializeField] private BuildingTimerLabel _buildingTimerLabel;
        [SerializeField] private AddTurretADButton _addTurretButton;
        [SerializeField] private OffTimerADButton _offTimerButton;

        private Action[] _uiHandlers;

        private void OnEnable()
        {
            _uiHandlers = new Action[]
            {
                () => SetBuildStateUI(true),
                () => SetAllButtonsStatus(false),
                () => SetAllButtonsStatus(true),
                () => SetBuildStateUI(false)
            };

            _buildState.Entered += _uiHandlers[0];
            _trainingState.Entered += _uiHandlers[0];
            _trainingState.Entered += _uiHandlers[1];
            _trainingState.Exited += _uiHandlers[2];
            _defenseState.Entered += _uiHandlers[3];
            _defenseState.Exited += Close;
        }

        private void OnDisable()
        {
            _buildState.Entered -= _uiHandlers[0];
            _trainingState.Entered -= _uiHandlers[0];
            _trainingState.Entered -= _uiHandlers[1];
            _trainingState.Exited -= _uiHandlers[2];
            _defenseState.Entered -= _uiHandlers[3];
            _defenseState.Exited -= Close;
        }

        private void SetBuildStateUI(bool isActive)
        {
            _turretsAmountLabel.gameObject.SetActive(isActive);
            _buildingTimerLabel.gameObject.SetActive(isActive);
            _addTurretButton.gameObject.SetActive(isActive);
            _offTimerButton.gameObject.SetActive(isActive);
        }

        private void SetAllButtonsStatus(bool isActive)
        {
            foreach (Button button in GetComponentsInChildren<Button>())
            {
                button.enabled = isActive;
            }
        }
    }
}