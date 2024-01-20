using System;
using System.Collections.Generic;

public interface IWave
{
    public event Action EnemiesDestroyed;

    IReadOnlyList<float> RouteData { get; }
    bool IsSpawned { get; }
    Enemy GetNextEnenmyToSpawn();

    void Clear();
}
