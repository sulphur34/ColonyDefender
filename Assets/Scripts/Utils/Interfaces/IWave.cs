using System;

public interface IWave
{
    public event Action EnemiesDestroyed;
    void Activate();

    void Clear();
}
