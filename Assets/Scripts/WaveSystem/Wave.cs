using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wave : IWave 
{
    private List<Queue<Enemy>> _enemiesByRoute;
    private List<Enemy> _enemies;
    private List<float> _routeData;
    private int _nextEnemyIndex;

    public event Action EnemiesDestroyed;

    public IReadOnlyList<float> RouteData => _routeData;
    public int RoutesCount => _routeData.Count;
    public bool IsSpawned {  get; private set; }
    
    public Wave(List<Queue<Enemy>> enemies)
    {
        _enemiesByRoute = enemies;
        SetWaveParameters();
        _nextEnemyIndex = 0;
    }   
    
    public Enemy GetNextEnenmyToSpawn()
    {
        if(_enemiesByRoute.Count <= 0)
        {
            IsSpawned = true;
            return null;
        }

        if (_enemiesByRoute[_nextEnemyIndex].Count <= 0)
        {
            _enemiesByRoute.RemoveAt(_nextEnemyIndex);
            SetNextIndex();
            return null;
        }
        else
        {
            return _enemiesByRoute[_nextEnemyIndex].Dequeue();
        }
    }

    public void Clear()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)  
                MonoBehaviour.Destroy(enemy.gameObject);
        }
    }

    private void SetNextIndex()
    {
        if(_nextEnemyIndex < _enemiesByRoute.Count - 1)
            _nextEnemyIndex++;
        else
            _nextEnemyIndex = 0;
    }
    private void RemoveOnDeath(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
            EnemiesDestroyed?.Invoke();
    }

    private void SetWaveParameters()
    {
        _routeData = new List<float>(_enemiesByRoute.Count);
        _enemies = new List<Enemy>();

        for (int i = 0; i < _enemiesByRoute.Count; i++)
        {
            _routeData.Add(_enemiesByRoute[i].Select(enemy => enemy.Health.CurrentHealth).Sum());
            _enemies.AddRange(_enemiesByRoute[i]);
        }

        foreach (Enemy enemy in _enemies)
            enemy.Died += RemoveOnDeath;
    }
}
