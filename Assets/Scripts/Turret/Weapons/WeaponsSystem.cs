using System.Collections;
using UnityEngine;

public class WeaponsSystem: MonoBehaviour
{
    [SerializeField] private float _timeToNextWeaponActivation = 1;

    private Transform _transform;
    private Transform _target;
    private Coroutine _aimCoroutine;
    private Coroutine _activationCoroutine;
    private WaitForSeconds _weaponsActivationDelay;
    private IWeapon[] _weapons;

    private void Awake()
    {
        _transform = transform;
        _weaponsActivationDelay = new WaitForSeconds(_timeToNextWeaponActivation);
        Initialize();
    }

    public void Activate(Transform target)
    {        
        _target = target;
        _aimCoroutine = StartCoroutine(StayOnTarget());
        _activationCoroutine = StartCoroutine(ActivateAll());
    }

    public void Deactivate() 
    {
        StopCoroutine(_aimCoroutine);
        StopCoroutine(_activationCoroutine);        
        StartCoroutine(DeactivateAll());
    }

    private void Initialize()
    {
        _weapons = GetComponentsInChildren<Weapon>();
    }

    private IEnumerator StayOnTarget()
    {
        GameObject targetObject = _target.gameObject;

        while (targetObject.activeSelf)
        {    
            _transform.LookAt(_target.position);
            yield return null;
        }
    }

    private IEnumerator ActivateAll()
    {
        foreach (var weapon in _weapons)
        {
            weapon.StartFire();
            yield return _weaponsActivationDelay;
        }            
    }

    private IEnumerator DeactivateAll()
    {
        foreach (var weapon in _weapons)
        {
            weapon.EndFire();
            yield return null;
        }
    }
}
