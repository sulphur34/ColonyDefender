using System.Collections;
using EnemySystem;
using UnityEngine;

namespace TurretSystem.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _collisionParticle;
        [SerializeField] private ParticleSystem _projectileParticle;
        [SerializeField] private float _damage;

        private Rigidbody _rigidbody;
        private Collider _collider;
        private Vector3 _startPosition;
        private Coroutine _coroutine;
        private Transform _transform;
        private float _timeToDisable;
        private WaitForSeconds _disableDelay;
        private WaitForSeconds _onEnemyCollisionDelay;

        protected Vector3 CurrentPosition => _transform.position;

        protected virtual void Awake()
        {
            _timeToDisable = 3f;
            _disableDelay = new WaitForSeconds(_timeToDisable);
            _onEnemyCollisionDelay = new WaitForSeconds(_collisionParticle.main.duration);
            _transform = transform;
            _collider = GetComponent<Collider>();
            _startPosition = _transform.position;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void OnEnable()
        {
            _collider.enabled = true;
            _transform.position = _startPosition;
            _projectileParticle.Play();
            _coroutine = StartCoroutine(DisableAfterDelay(_disableDelay));
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
            _rigidbody.velocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (TryGetEnemy(other, out Enemy enemy))
            {
                OnEnemyCollision(enemy);
            }
        }

        public void Initialize(float damageMultiplier)
        {
            _damage *= damageMultiplier;
        }

        public void ApplyForce(Vector3 force)
        {
            _transform.LookAt(force);
            _rigidbody.AddForce(force);
        }

        protected bool TryGetEnemy(Collider other, out Enemy enemy)
        {
            if (other.TryGetComponent(out enemy))
            {
                return true;
            }

            enemy = null;
            return false;
        }

        protected virtual void OnEnemyCollision(Enemy enemy)
        {
            InflictDamage(enemy);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            DisableOnEnemyCollision();
        }

        protected virtual void InflictDamage(Enemy enemy)
        {
            enemy.Damageable.TakeDamage(_damage);
        }

        protected void PlayCollisionParticle()
        {
            _collisionParticle.Play();
        }

        protected virtual void DisableOnEnemyCollision()
        {
            _projectileParticle.Clear();
            PlayCollisionParticle();
            _collider.enabled = false;
            _coroutine = StartCoroutine(DisableAfterDelay(_onEnemyCollisionDelay));
        }

        private IEnumerator DisableAfterDelay(WaitForSeconds delay)
        {
            yield return delay;
            _projectileParticle.Clear();
            gameObject.SetActive(false);
        }
    }
}