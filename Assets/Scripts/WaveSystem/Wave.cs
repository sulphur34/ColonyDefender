using System;
using System.Collections.Generic;
using UnityEngine;

public class Wave : IWave
{    
    private List<Enemy> _enemies;

    public event Action EnemiesDestroyed;

    public void Initialize(List<Enemy> enemies)
    {
        _enemies = enemies;
    }

    public void Activate()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.enabled = true;
            enemy.Died += RemoveOnDeath;
        }
    }    

    private void RemoveOnDeath(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if(_enemies.Count == 0)
            EnemiesDestroyed?.Invoke();
    }

    public void Clear()
    {
        foreach (Enemy enemy in _enemies)
        {
            MonoBehaviour.Destroy(enemy.gameObject);
        }
    }
}
