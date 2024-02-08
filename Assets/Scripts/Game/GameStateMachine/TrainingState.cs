using UnityEngine;
using UnityEngine.UI;

public class TrainingState : GameState
{
    [SerializeField] private TrainingMenu _firstLevelTrainingMenu;
    [SerializeField] private TrainingMenu _secondLevelTrainingMenu;
    [SerializeField] private Button _trainingSpawnButton;
    [SerializeField] private ColumnUI _columnUI;
    [SerializeField] private EnemyPowerUI _enemyPowerUI;

    private readonly int _firstLevel = 1;
    private readonly int _secondLevel = 2;

    public override void Enter()
    {
        base.Enter();
        _firstLevelTrainingMenu.enabled = true;
        _secondLevelTrainingMenu.enabled = true;
        Time.timeScale = 0f;
        _enemyPowerUI.Show();
        Initialize();
    }

    public override void Exit() 
    {
        _firstLevelTrainingMenu.enabled = false;
        _secondLevelTrainingMenu.enabled = false;
        base.Exit();
    }

    private void Initialize()
    {
        if (EnhancementSystem.GameLevelValue == _firstLevel)
        {
            _firstLevelTrainingMenu.Open();
            _trainingSpawnButton.gameObject.SetActive(true);
            _trainingSpawnButton.onClick.AddListener(SpawnTrainingTurret);
        }
        else if (EnhancementSystem.GameLevelValue == _secondLevel)
        {
            _secondLevelTrainingMenu.Open();
            _secondLevelTrainingMenu.Closed += SwitchToGame;
        }
    }
    
    private void SpawnTrainingTurret()
    {
        _trainingSpawnButton.gameObject.SetActive(false);
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
