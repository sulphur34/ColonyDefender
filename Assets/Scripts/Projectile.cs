using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Coroutine _coroutine;
    private Transform _transform;
    private float _timeToDisable;
    private WaitForSeconds _disableDelay;

    private void Awake()
    {
        _timeToDisable = 10;
        _disableDelay = new WaitForSeconds(_timeToDisable);
        _transform = transform;
        _startPosition = _transform.position;
        _coroutine = StartCoroutine(DisableAfterDelay());
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _transform.position = _startPosition;
            gameObject.SetActive(false);
        }
    }

    public void ApplyForce(Vector3 force)
    {
        _rigidbody.AddForce(force);
    }

    public IEnumerator DisableAfterDelay()
    {
        yield return _disableDelay;
        gameObject.SetActive(false);
    }
}
