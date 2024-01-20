using System;
using UnityEngine;

public class GameState : State
{
    [SerializeField] protected EnhancementSystem EnhancementSystem;
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
