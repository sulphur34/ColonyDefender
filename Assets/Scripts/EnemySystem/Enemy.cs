using System;
using UnityEngine;
using Utils.Interfaces;

namespace EnemySystem
{
    [RequireComponent(typeof(AIMover))]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    [RequireComponent(typeof(BoxCollider))]
    public class Enemy : MonoBehaviour
    {
        private Health _health;
        private AIMover _mover;
        private BoxCollider _boxCollider;
        private Transform _transform;

        public event Action<Enemy> Died;

        public event Action<Enemy> Destroyed;

        public bool IsAlive => Health.CurrentHealth > 0;
        public IHealth Health => _health;
        public IDamageable Damageable => _health;
        public Vector3 AimPoint => _transform.TransformPoint(_boxCollider.center);

        private void Awake()
        {
            _transform = transform;
            _mover = GetComponent<AIMover>();
            _boxCollider = GetComponent<BoxCollider>();
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
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}