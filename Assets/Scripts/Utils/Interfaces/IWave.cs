using EnemySystem;
using System;
using System.Collections.Generic;

namespace Utils.Interfaces
{
    public interface IWave
    {
        public event Action EnemiesDestroyed;

        public IReadOnlyList<float> RouteData { get; }
        public bool IsSpawned { get; }
        public Enemy GetNextEnenmyToSpawn();

        public void Clear();
    }
}