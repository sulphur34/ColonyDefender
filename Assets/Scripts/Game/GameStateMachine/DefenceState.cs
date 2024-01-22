using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceState : GameState
{
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private Barrier _barrier;

    private IWave _wave;
    private float _spawnDelay = 0.1f;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void Awake()
    {
        LevelFactory.Built += (level) => _wave = level.Wave;
        _waitForSeconds = new WaitForSeconds(_spawnDelay);
    }

    public override void Enter()
    {
        base.Enter();
        _barrier.EnemyInvaded += Switcher.SwitchState<LooseState>;
        _wave.EnemiesDestroyed += Switcher.SwitchState<WinState>;
        _coroutine = StartCoroutine(Spawn());
    }

    public override void Exit()
    {
        StopCoroutine(_coroutine);
        _wave.Clear();
        base.Exit();
    }
    
    public IEnumerator Spawn()
    {
        while (_wave.IsSpawned == false)
        {
            Enemy enemy = _wave.GetNextEnenmyToSpawn();

            if (enemy != null)
            {
                enemy.gameObject.SetActive(true);
                enemy.Move();
            }

            yield return null;
        }
    }
}
