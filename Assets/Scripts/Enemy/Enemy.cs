using System;
using UnityEngine;

[RequireComponent(typeof(AIMover))]
[RequireComponent (typeof(SkinnedMeshRenderer))]
public class Enemy : MonoBehaviour
{
    private Health _health;
    private AIMover _mover;
        
    public event Action<Enemy> Died;
    public event Action<Enemy> Destroyed;

    public bool IsAlive => Health.CurrentHealth > 0;
    public IHealth Health => _health;
    public IDamageable Damager => _health;


    private void Awake()
    {
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
        gameObject.SetActive(false);
    }
}
