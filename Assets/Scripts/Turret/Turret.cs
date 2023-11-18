using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    [SerializeField] private WeaponsSystem _weaponSystem;
    [SerializeField] private EnemyTrackSystem _enemyTrackSystem;

    private Enemy _currentEnemy;
    private Vector3 _currentPosition;
    private Coroutine _coroutine;

    public UnityAction EnemyFound;
    
    private void Start()
    {        
        _currentPosition = transform.position;
        EnemyFound += AttackEnemy;
        _coroutine = StartCoroutine(SearchForEnemy());        
    }

    public void Initialize(EnemyTrackSystem enemyTrackSystem)
    {
        _enemyTrackSystem = enemyTrackSystem;
        _currentPosition = transform.position;
        EnemyFound += AttackEnemy;
    }

    private IEnumerator SearchForEnemy()
    {
        while (_currentEnemy == null)
        {
            if (_enemyTrackSystem.TryGetNearestEnemy(_currentPosition, out Enemy newEnemy))
            {
                _currentEnemy = newEnemy;
            }

            yield return null;
        }

        EnemyFound.Invoke();
    }

    private void AttackEnemy()
    {
        _weaponSystem.Activate(_currentEnemy.transform);
        _currentEnemy.Health.Died += StopAttack;
    }

    private void StopAttack()
    {
        _weaponSystem.Deactivate();
        _currentEnemy = null;
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SearchForEnemy());
    }
}
