using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class WeaponsSystem: MonoBehaviour, IWeaponSystem
{
    [SerializeField] private float _timeToNextWeaponActivation = 1;

    private Transform _transform;
    private MeshRenderer _meshRenderer;
    private Transform _target;
    private Coroutine _aimCoroutine;
    private Coroutine _activationCoroutine;
    private WaitForSeconds _weaponsActivationDelay;
    private List<IWeapon> _weapons;

    private void Awake()
    {
        _transform = transform;
        _meshRenderer = GetComponent<MeshRenderer>();
        _weaponsActivationDelay = new WaitForSeconds(_timeToNextWeaponActivation);
        _weapons = new List<IWeapon>();
    }

    private void OnDestroy()
    {
        DeactivateGuns();
    }

    public void Initialize(Material material, Weapon weapon, GunScheme gunsPosition, WeaponMultipliers weaponParameters)
    {
        _meshRenderer.material = material;

        foreach (Vector3 gunPosition in gunsPosition)
        {
            Weapon newWeapon = Instantiate(weapon, gunPosition, Quaternion.identity, _transform);
            newWeapon.Initialize(weaponParameters.Damage, weaponParameters.FireRate);
            _weapons.Add(newWeapon);
        }
    }

    public void Activate(Transform target)
    {        
        _target = target;
        _aimCoroutine = StartCoroutine(StayOnTarget());
        _activationCoroutine = StartCoroutine(ActivateGuns());
    }

    public void Deactivate()
    {
        if(_aimCoroutine != null)
            StopCoroutine(_aimCoroutine);

        if( _activationCoroutine != null)
            StopCoroutine(_activationCoroutine);

        DeactivateGuns();
    }

    private IEnumerator StayOnTarget()
    {
        GameObject targetObject = _target.gameObject;

        while (targetObject != null)
        {
            _transform.LookAt(_target.transform.position);
            yield return null;
        }
    }

    private IEnumerator ActivateGuns()
    {
        foreach (var weapon in _weapons)
        {
            weapon.StartFire();
            yield return _weaponsActivationDelay;
        }            
    }

    private void DeactivateGuns()
    {
        foreach (var weapon in _weapons)
        {
            weapon.EndFire();
        }
    }
}
