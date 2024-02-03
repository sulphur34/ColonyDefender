using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTrackSystem : MonoBehaviour
{
    [SerializeField] private DefenceState _defenceState;

    private List<Enemy> _enemiesInAttackZone;

    private void Awake()
    {
        _enemiesInAttackZone = new List<Enemy>();
        _defenceState.Exited += Reset;
    }

    public bool TryGetNearestEnemy(Vector3 originalPosition, out Enemy enemy)
    {
        enemy = null;

        if (_enemiesInAttackZone.Count < 0)
            return false;

        enemy = _enemiesInAttackZone.
            OrderBy(enemyInZone => Vector3.Distance(enemyInZone.transform.position, originalPosition))
            .FirstOrDefault();

        if(enemy == null)
            return false;

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            RemoveEnemy(enemy);
        }
    }

    private void AddEnemy(Enemy enemy)
    {
        _enemiesInAttackZone.Add(enemy);
        enemy.Died += RemoveEnemy;
        enemy.Destroyed += RemoveEnemy;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemiesInAttackZone.Remove(enemy);
        enemy.Died -= RemoveEnemy;
        enemy.Destroyed -= RemoveEnemy;
    }

    private void Reset()
    {
        if (_enemiesInAttackZone.Count == 0) 
            return;

        _enemiesInAttackZone.Clear();
    }
}
