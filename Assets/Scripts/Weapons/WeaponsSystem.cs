using System.Collections;
using UnityEngine;

public class WeaponsSystem: MonoBehaviour
{
    [SerializeField] private ProjectileWeapon[] weapons;

    private Transform _transform;
    private Transform _target;
    private Coroutine _coroutine;

    private void Awake()
    {
        _transform = transform;
    }

    public void Activate(Transform target)
    {        
        _target = target;
        _coroutine = StartCoroutine(StayOnTarget());

        foreach (var weapon in weapons)
            weapon.StartFire();
    }

    public void Deactivate() 
    {
        StopCoroutine(_coroutine);

        foreach(var weapon in weapons)
            weapon.EndFire();
    }

    private IEnumerator StayOnTarget()
    {
        GameObject targetObject = _target.gameObject;

        while (targetObject.activeSelf)
        {
            Vector3 rotationPosition = new Vector3(_target.position.x, 0f, _target.position.z);
            _transform.LookAt(_target.position);
            yield return null;
        }
    }
}
