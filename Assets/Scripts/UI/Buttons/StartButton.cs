using EnhancementSystem;
using GameSystem.GameStateMachineSystem;
using UnityEngine;

namespace UI.Buttons
{
    public class StartButton : MenuSwitchButton
    {
        private const float TrainingLevelsValue = 2;

        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private EnhancementManager _enhancementSystem;

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
}