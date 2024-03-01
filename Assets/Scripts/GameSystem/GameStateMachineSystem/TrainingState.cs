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
        [SerializeField] private TrainingMenu _firstLevelTrainingMenu;
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
            _enemyPowerUI.Show();
            Initialize();
        }

        public override void Exit()
        {
            _firstLevelTrainingMenu.enabled = false;
            _trainingSpawnButton.gameObject.SetActive(false);
            base.Exit();
        }

        private void Initialize()
        {
            _firstLevelTrainingMenu.Open();
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