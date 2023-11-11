using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTrackSystem : MonoBehaviour
{
    private List<Enemy> _enemiesInAttackZone;

    private void Awake()
    {
        _enemiesInAttackZone = new List<Enemy>();
    }

    public bool TryGetNearestEnemy(Vector3 originalPosition, out Enemy enemy)
    {
        enemy = null;

        if (_enemiesInAttackZone.Count < 0)
            return false;

        enemy = _enemiesInAttackZone.
            OrderBy(enemyInZone => Vector3.Distance(enemyInZone.transform.position, originalPosition))
            .FirstOrDefault();

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemiesInAttackZone.Add(enemy);
            enemy.Die.AddListener(OnEnemyDeath);
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        _enemiesInAttackZone.Remove(enemy);
    }
}
