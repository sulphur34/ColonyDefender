using System;
using UnityEngine;

public class GameState : State
{
    [SerializeField] protected EnhancementSystem _enhancementSystem;
    [SerializeField] protected CellBoard _cellBoard;

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
