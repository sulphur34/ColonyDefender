using EnhancementSystem;
using System;
using TurretSpawnSystem.CellSystem;
using UnityEngine;

namespace GameSystem.GameStateMachineSystem
{
    public class GameState : State
    {
        [SerializeField] protected EnhancementManager EnhancementSystem;
        [SerializeField] protected CellBoard CellBoard;
        [SerializeField] protected LevelFactory LevelFactory;

        public event Action Entered;
        public event Action Exited;

        public override void Enter()
        {
            base.Enter();
            Entered?.Invoke();
        }

        public override void Exit()
        {
            base.Exit();
            Exited?.Invoke();
        }
    }
}
