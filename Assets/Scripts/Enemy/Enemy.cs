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

    public bool IsAlive { get; private set; }
    public IHealth Health => _health;
    public IDamageable Damager => _health;


    private void Awake()
    {
        _transform = transform;
        _mover = GetComponent<AIMover>();
        _meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }    
        
    public void Initialize(float healthValue, IRoute route)
    { 
        _health = new Health(healthValue);
        Health.Died += OnDie;
        _mover.Initialize(route);
        _meshRenderer.enabled = false;
    }

    public void Move()
    {
        _meshRenderer.enabled = true;
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
        Destroy(gameObject, destroyDelay);
    }
}
