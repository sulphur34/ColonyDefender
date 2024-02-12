using System;
using System.Collections.Generic;

public interface IWave
{
    public event Action EnemiesDestroyed;

    public IReadOnlyList<float> RouteData { get; }
    public bool IsSpawned { get; }
    public Enemy GetNextEnenmyToSpawn();

    public void Clear();
}
