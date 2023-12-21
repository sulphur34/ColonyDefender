using System;
using UnityEngine.Events;

public interface IGameHandler
{    
    public event Action Started;
    public event Action<int> TurretAdded;
    public event Action<int> TimerChange;
    public event Action BaseBuilt;

    public int CurrentLevel { get; }
    public int MinLevelInBatch { get; }
    public int MaxLevelInBatch { get; }
    public int LevelBatchValue { get; }
    public int TimeLeftToBuild { get; }
}
