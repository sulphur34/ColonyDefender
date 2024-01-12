using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveFactory : MonoBehaviour, IFactory<IWave>
{
    [SerializeField] private float _defaultHealthValue;
    [SerializeField] private SpawnGrid _spawnGrid;
    [SerializeField] private EnemyData[] _enemyData;

    private delegate SpawnTile Spawn();

    public IWave Build(float level)
    {
        Wave newWave = new Wave();        
        WaveData waveData = new WaveData(level, _spawnGrid.MaxCapacity, _enemyData.Length, _defaultHealthValue);
        EnemyData enemyData = _enemyData[waveData.ModelIndex];
        Enemy enemyPrefab = enemyData.EnemyPrefab;
        IEnumerable<Enemy> enemiesInWave = new List<Enemy>();

        if (waveData.IsBossLevel)
        {
            enemiesInWave =
                CreateEnemies(enemyPrefab, enemyData.Boss, waveData.BossHealth, _spawnGrid.GetBossPlace);
        }
        else
        {
            enemiesInWave = enemiesInWave
                .Concat(CreateEnemies(enemyPrefab, enemyData.Large, 
                waveData.LargeEnemyHealth, _spawnGrid.GetLargeTile, waveData.LargeEnemyAmount))
                .Concat(CreateEnemies(enemyPrefab, enemyData.Medium, 
                waveData.MediumEnemyHealth, _spawnGrid.GetMediumTile, waveData.MediumEnemyAmount))
                .Concat(CreateEnemies(enemyPrefab, enemyData.Small, 
                waveData.SmallEnemyHealth, _spawnGrid.GetSmallTile, waveData.SmallEnemyAmount));
        }

        newWave.Initialize(enemiesInWave.ToList());
        _spawnGrid.Clear();

        return newWave;
    }

    private List<Enemy> CreateEnemies(Enemy enemyPrefab, EnemyParameters enemyParameters, float health, Spawn positionGetter, int amount = 1) 
    {
        List<Enemy> enemies = new List<Enemy>();

        for (int i = 0; i < amount; i++)
        {
            SpawnTile tile = positionGetter.Invoke();

            if (tile != null)
            {
                Vector3 spawnPlace = new Vector3(tile.SpawnPosition.x, enemyParameters.Height, tile.SpawnPosition.y);
                Enemy enemy = Instantiate(enemyPrefab, spawnPlace, Quaternion.identity);
                enemy.Initialize(health, enemyParameters.Scale);
                enemies.Add(enemy);
            }
        }

        return enemies;
    }
}


