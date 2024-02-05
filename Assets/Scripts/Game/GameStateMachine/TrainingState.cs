using UnityEngine;
using UnityEngine.UI;

public class TrainingState : GameState
{
    [SerializeField] private TrainingMenu _firstLevelTrainingMenu;
    [SerializeField] private TrainingMenu _secondLevelTrainingMenu;
    [SerializeField] private Button _trainingSpawnButton;
    [SerializeField] private ColumnUI _columnUI;
    [SerializeField] private EnemyPowerUI _enemyPowerUI;

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0f;
        _enemyPowerUI.Show();
        _firstLevelTrainingMenu.Open();
        _trainingSpawnButton.gameObject.SetActive(true);
        _trainingSpawnButton.onClick.AddListener(SpawnTrainingTurret);
    }

    public override void Exit() 
    {
        base.Exit();
    }
    
    private void SpawnTrainingTurret()
    {
        _trainingSpawnButton.gameObject.SetActive(false);
        _firstLevelTrainingMenu.Close();
        Time.timeScale = 1f;
        Switcher.SwitchState<BuildState>();
        _columnUI.SpawnTurret();
    }
}
