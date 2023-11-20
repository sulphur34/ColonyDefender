using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Health _health;
    public bool IsAlive { get; private set; }
    
    public UnityEvent<Enemy> Died;
    public IHealth Health => _health;
    public IDamageable Damager => _health;

    private void Awake()
    {
        _health = new Health(200);
        Health.Died += OnDie;
    }

    private void Update()
    {
        transform.Translate(-transform.forward * Time.deltaTime);
    }
        
    public void Initialize(EnemyData enemyData)
    {
        Health.Died += OnDie;
    }
    
    public void OnDie()
    {
        float destroyDelay = 0.1f;
        IsAlive = false;
        Died.Invoke(this);
        Destroy(gameObject, destroyDelay);
    }
}
