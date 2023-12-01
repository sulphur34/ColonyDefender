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
        _activationCoroutine = StartCoroutine(ActivateAll());
    }

    public void Deactivate() 
    {
        StopCoroutine(_aimCoroutine);
        StopCoroutine(_activationCoroutine);        
        StartCoroutine(DeactivateAll());
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
