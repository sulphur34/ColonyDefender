using UnityEngine;

public class DefenceState : GameState
{
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private Barrier _barrier;

    private IWave _wave;

    public override void Enter()
    {
        base.Enter();
        _wave = _waveFactory.Build(_enhancementSystem.GameLevelValue);
        _barrier.EnemyInvaded += Switcher.SwitchState<LooseState>;
        _wave.EnemiesDestroyed += Switcher.SwitchState<WinState>;
        _wave.Activate();
    }

    public override void Exit()
    {
        _wave.Clear();
        base.Exit();
    }
}
