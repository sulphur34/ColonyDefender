using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionParticle;
    [SerializeField] private float _damage;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Coroutine _coroutine;
    private Transform _transform;
    private float _timeToDisable;
    private WaitForSeconds _disableDelay;

    private void Awake()
    {
        _timeToDisable = 3;
        _disableDelay = new WaitForSeconds(_timeToDisable);
        _transform = transform;
        _startPosition = _transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DisableAfterDelay());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Damager.TakeDamage(_damage);
            ParticleSystem burst = Instantiate(_collisionParticle, _transform.position, Quaternion.identity);
            burst.Play();
            _transform.position = _startPosition;
            gameObject.SetActive(false);
        }
    }

    public void ApplyForce(Vector3 force)
    {
        _transform.LookAt(force);
        _rigidbody.AddForce(force);
    }

    public IEnumerator DisableAfterDelay()
    {
        yield return _disableDelay;
        gameObject.SetActive(false);
    }
}
