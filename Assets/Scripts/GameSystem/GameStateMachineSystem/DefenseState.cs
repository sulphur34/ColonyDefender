using EnemySystem;
using System.Collections;
using UnityEngine;
using Utils.Interfaces;

namespace GameSystem.GameStateMachineSystem
{
    public class DefenseState : GameState
    {
        [SerializeField] private Barrier _barrier;

        private IWave _wave;
        private Coroutine _coroutine;

        private void Awake()
        {
            LevelFactory.Built += (level) => _wave = level.Wave;
        }

        public override void Enter()
        {
            base.Enter();
            _barrier.EnemyInvaded += OnLoose;
            _wave.EnemiesDestroyed += OnWin;
            _coroutine = StartCoroutine(Spawning());
        }

        public override void Exit()
        {
            StopCoroutine(_coroutine);
            _wave.Clear();
            CellBoard.Clear();
            base.Exit();
        }

        private IEnumerator Spawning()
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

        private void OnWin()
        {
            EnhancementSystem.SetMaxTurretLevel(CellBoard);
            Switcher.SwitchState<WinState>();
        }

        private void OnLoose()
        {
            Switcher.SwitchState<LooseState>();
        }
    }
}
