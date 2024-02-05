using System;
using UnityEngine;

public class PauseState : GameState
{
    public Level Level { get; private set; }

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0;
        Level?.Clear();
    }

    public override void Exit() 
    {
        base.Exit();
        Time.timeScale = 1;
        Level = LevelFactory.Build(EnhancementSystem.GameLevelValue);
    }
}
