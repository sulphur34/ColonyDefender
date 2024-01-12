using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Health _health;
    private Transform _transform;
        
    public event Action<Enemy> Died;

    public bool IsAlive { get; private set; }
    public IHealth Health => _health;
    public IDamageable Damager => _health;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        transform.Translate(-transform.forward * Time.deltaTime * _speed);
    }
        
    public void Initialize(float healthValue, float scale)
    {
        _transform.localScale = new Vector3 (scale, scale, scale);
        _health = new Health(healthValue);
        Health.Died += OnDie;
    }
    
    private void OnDie()
    {
        float destroyDelay = 0.1f;
        IsAlive = false;
        Died.Invoke(this);        
        Destroy(gameObject, destroyDelay);
    }
}
