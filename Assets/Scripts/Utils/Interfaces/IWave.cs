using System;
using System.Collections.Generic;
using EnemySystem;

namespace Utils.Interfaces
{
    public interface IWave
    {
        public event Action EnemiesDestroyed;

        public IReadOnlyList<float> RouteData { get; }
        public bool IsSpawned { get; }

        public Enemy GetNextEnemyToSpawn();

        public void Clear();
    }
}