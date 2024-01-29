using System;
using UnityEngine;

[RequireComponent(typeof(AIMover))]
[RequireComponent (typeof(SkinnedMeshRenderer))]
public class Enemy : MonoBehaviour
{
    private Health _health;
    private AIMover _mover;
    private Transform _transform;
    private SkinnedMeshRenderer _meshRenderer;
        
    public event Action<Enemy> Died;
    public event Action<Enemy> Destroyed;

    public bool IsAlive { get; private set; }
    public IHealth Health => _health;
    public IDamageable Damager => _health;


    private void Awake()
    {
        _transform = transform;
        _mover = GetComponent<AIMover>();
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void Initialize(float healthValue, IRoute route)
    { 
        _health = new Health(healthValue);
        Health.Died += OnDie;
        _mover.Initialize(route);
    }

    public void Move()
    {
        _mover.Activate();
    }
    
    public void Stop()
    {
        _mover.Deactivate();
    }

    private void OnDie()
    {
        Died.Invoke(this);        
        float destroyDelay = 0.1f;
        IsAlive = false;
        gameObject.SetActive(false);
        //Destroy(gameObject, destroyDelay);
    }
}
