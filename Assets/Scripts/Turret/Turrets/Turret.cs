using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Turret : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turretLevelLabel;    
    
    private WeaponsSystem _weaponSystem;
    private EnemyTrackSystem _enemyTrackSystem;
    private Enemy _currentEnemy;
    private Vector3 _currentPosition;
    private Coroutine _coroutine;

    public UnityAction EnemyFound;

    public IWeaponSystem WeaponSystem => _weaponSystem;
    public float TurretLevel { get; private set; }
    
    private void Awake()
    {
        _weaponSystem = GetComponentInChildren<WeaponsSystem>();
        _currentPosition = transform.position;
        EnemyFound += AttackEnemy;  
    }

    public void Initialize(EnemyTrackSystem enemyTrackSystem, float turretLevel)
    {
        _enemyTrackSystem = enemyTrackSystem;
        TurretLevel = turretLevel;
        _turretLevelLabel.text = TurretLevel.ToString();
        _coroutine = StartCoroutine(SearchForEnemy());
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
        _currentEnemy.Health.Died += Restart;
    }

    private void StopAttack()
    {
        _weaponSystem.Deactivate();
        _currentEnemy = null;

        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Restart()
    {
        StopAttack();
        _coroutine = StartCoroutine(SearchForEnemy());
    }
}
