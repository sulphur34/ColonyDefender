using UI.Buttons;
using UI.Buttons.ADButtons;
using UI.EnemyPowerUI;
using UI.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem.GameStateMachineSystem
{
    public class TrainingState : GameState
    {
        private readonly int _firstLevel = 1;
        private readonly int _secondLevel = 2;

        [SerializeField] private TrainingMenu _firstLevelTrainingMenu;
        [SerializeField] private TrainingMenu _secondLevelTrainingMenu;
        [SerializeField] private Button _trainingSpawnButton;
        [SerializeField] private ColumnUI _columnUI;
        [SerializeField] private EnemyPowerPanel _enemyPowerUI;
        [SerializeField] private AddTurretADButton _addTurretButton;
        [SerializeField] private OffTimerADButton _offTimerButton;

        private void OnEnable()
        {
            _trainingSpawnButton.onClick.AddListener(SpawnTrainingTurret);
        }

        private void OnDisable()
        {
            _trainingSpawnButton.onClick.RemoveListener(SpawnTrainingTurret);
        }

        public override void Enter()
        {
            base.Enter();
            _addTurretButton.enabled = true;
            _offTimerButton.enabled = true;
            _firstLevelTrainingMenu.enabled = true;
            _secondLevelTrainingMenu.enabled = true;
            _enemyPowerUI.Show();
            Initialize();
        }

        public override void Exit()
        {
            _firstLevelTrainingMenu.enabled = false;
            _secondLevelTrainingMenu.enabled = false;
            _trainingSpawnButton.gameObject.SetActive(false);
            base.Exit();
        }

        private void Initialize()
        {
            if (EnhancementSystem.GameLevelValue == _firstLevel)
            {
                _firstLevelTrainingMenu.Open();
            }
            else if (EnhancementSystem.GameLevelValue == _secondLevel)
            {
                _secondLevelTrainingMenu.Open();
                _secondLevelTrainingMenu.Closed += SwitchToGame;
            }
        }

        private void SpawnTrainingTurret()
        {
            _firstLevelTrainingMenu.Close();
            SwitchToGame();
            _columnUI.SpawnTurret();
        }

        private void SwitchToGame()
        {
            Time.timeScale = 1f;
            Switcher.SwitchState<BuildState>();
        }
    }
}