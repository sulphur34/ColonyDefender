using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrailRenderer))]
[RequireComponent (typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionParticle;
    [SerializeField] private float _damage;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _startPosition;
    private Coroutine _coroutine;
    private Transform _transform;
    private float _timeToDisable;
    private WaitForSeconds _disableDelay;
    private WaitForSeconds _onEnemyCollisionDelay;
    private TrailRenderer _trailRenderer;

    protected Vector3 CurrentPosition => _transform.position;

    private void Awake()
    {
        _timeToDisable = 3f;
        _trailRenderer = GetComponent<TrailRenderer>();
        _disableDelay = new WaitForSeconds(_timeToDisable);
        _onEnemyCollisionDelay = new WaitForSeconds(_collisionParticle.main.duration);
        _transform = transform;
        _collider = GetComponent<Collider>();
        _startPosition = _transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _collider.enabled = true;
        _transform.position = _startPosition;
        _trailRenderer.Clear();
        _trailRenderer.ResetBounds();
        _trailRenderer.enabled = true;
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
        enemy.Damager.TakeDamage(_damage);
    }

    private IEnumerator DisableAfterDelay(WaitForSeconds delay)
    {
        yield return delay;
        gameObject.SetActive(false);
    }

    private void DisableOnEnemyCollision()
    {
        _collisionParticle.Play();
        _collider.enabled = false;
        _trailRenderer.enabled = false;
        _coroutine = StartCoroutine(DisableAfterDelay(_onEnemyCollisionDelay));
    }    
}
