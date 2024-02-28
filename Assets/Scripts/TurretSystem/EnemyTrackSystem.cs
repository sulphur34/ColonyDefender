using EnemySystem;
using GameSystem.GameStateMachineSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TurretSystem
{
    public class EnemyTrackSystem : MonoBehaviour
    {
        [SerializeField] private DefenseState _defenseState;

        private List<Enemy> _enemiesInAttackZone;

        private void Awake()
        {
            _enemiesInAttackZone = new List<Enemy>();
            _defenseState.Exited += Reset;
        }

        public bool TryGetNearestEnemy(Vector3 originalPosition, out Enemy enemy)
        {
            enemy = null;

            if (_enemiesInAttackZone.Count < 0)
                return false;

            enemy = _enemiesInAttackZone.
                OrderBy(enemyInZone => Vector3.Distance(enemyInZone.transform.position, originalPosition))
                .FirstOrDefault();

            return enemy != null;
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
}