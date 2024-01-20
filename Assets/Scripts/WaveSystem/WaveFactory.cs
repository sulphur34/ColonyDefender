using System.Collections.Generic;
using UnityEngine;

public class WaveFactory : IFactory<IWave>
{
    private Location _location;
    private EnemyData _enemyData;
    private float _defaultHealth = 60;
    private List<Queue<Enemy>> _enemiesByRoute;

    public WaveFactory(Location location, EnemyData enemyData)
    {
        _location = location;
        _enemyData = enemyData;
    }

    public IWave Build(float levelIndex)
    {
        WaveData waveData = new WaveData(levelIndex);
        Enemy enemyPrefab = _enemyData.EnemyPrefab;
        _enemiesByRoute = new List<Queue<Enemy>>();

        for (int i = 0; i < _location.RoutesAmount; i++)
            _enemiesByRoute.Add(new Queue<Enemy>());

        if (waveData.IsBossLevel)
        {
            GenerateBoss(enemyPrefab, _enemyData.Boss, _defaultHealth * levelIndex);
        }
        else
        {
            GenerateEnemies(enemyPrefab, _enemyData.Large,
                _defaultHealth * waveData.LargeEnemyMultiplier, waveData.LargeEnemyAmount);
            GenerateEnemies(enemyPrefab, _enemyData.Medium,
                _defaultHealth * waveData.MediumEnemyMultiplier, waveData.MediumEnemyAmount);
            GenerateEnemies(enemyPrefab, _enemyData.Small,
                _defaultHealth * waveData.SmallEnemyMultiplier, waveData.SmallEnemyAmount);
        }

        Wave newWave = new Wave(_enemiesByRoute);
        return newWave;
    }

    private void GenerateEnemies(Enemy enemyPrefab, EnemyParameters enemyParameters, float health, float amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            IRoute route = GetRandomRoute(out int routeIndex);
            AddEnemyToWave(CreateEnemy(enemyPrefab, enemyParameters, health, route), routeIndex);
        }
    }
    
    private void GenerateBoss(Enemy enemyPrefab, EnemyParameters enemyParameters, float health)
    {
        int middlePointMultiplier = 2;
        int routeIndex = Mathf.CeilToInt(_location.RoutesAmount / middlePointMultiplier);
        IRoute route;
        _location.TryGetRoute(routeIndex, out route);
        AddEnemyToWave(CreateEnemy(enemyPrefab, enemyParameters, health, route), routeIndex);
    }

    private void AddEnemyToWave(Enemy enemy, int routeIndex)
    {        
        _enemiesByRoute[routeIndex].Enqueue(enemy);
    }

    private Enemy CreateEnemy(Enemy enemyPrefab, EnemyParameters enemyParameters, float health, IRoute route)
    {
        Enemy enemy = MonoBehaviour.Instantiate(enemyPrefab);
        Transform transform = enemy.transform; 
        float scale = enemyParameters.Scale;
        transform.localScale = new Vector3(scale, scale, -scale);
        transform.position = new Vector3(route.SpawnPoint.x, enemyParameters.Height, route.SpawnPoint.z);
        enemy.Initialize(health, route);
        return enemy;
    }

    private IRoute GetRandomRoute(out int routeIndex)
    {
        int routesAmount = _location.RoutesAmount;
        routeIndex = Random.Range(0, routesAmount-1);

        if (_location.TryGetRoute(routeIndex, out IRoute route))
            return route;
        
        return null;
    }
}
