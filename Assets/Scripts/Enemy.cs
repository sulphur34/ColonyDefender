using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private IDamageable _enemyHealth;
    public bool IsAlive { get; private set; }
    
    public UnityEvent<Enemy> Die;

    private void Awake()
    {
        _enemyHealth = new Health(20);
        _enemyHealth.Die += OnDie;
    }

    private void Update()
    {
        transform.Translate(-transform.forward * Time.deltaTime);
    }

    public void Initialize(EnemyData enemyData)
    {
        _enemyHealth.Die += OnDie;
    }
    
    public void OnDie()
    {
        IsAlive = false;
        Die.Invoke(this);
    }
}
