using System.Collections;
using UnityEngine;

public class Weapon : ObjectPool, IWeapon
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _fireForce;

    private float _fireRate;
    private WaitForSeconds _delayTime;
    private Coroutine _coroutine;
    private Transform _transform;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_fireRate);
        _transform = transform;
    }

    public void Initialize(float damage, float fireRate)
    {
        _fireRate = fireRate;
        base.Initialize(_projectile, damage);
    }

    public void StartFire()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    public void EndFire()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public IEnumerator Shoot()
    {
        bool isContinue = true;

        while (isContinue)
        {
            if (TryGetObject(out GameObject projectile))
            {
                projectile.SetActive(true);
                projectile.transform.position = _shootingPoint.position;
                projectile.GetComponent<Projectile>().ApplyForce(_transform.forward * _fireForce);
            }
            yield return _delayTime;
        }
    }

    protected override GameObject GetObjectWithParameter<T>(T prefab, float parameter) 
    {
        GameObject projectile = Instantiate(prefab.gameObject, transform);
        projectile.GetComponent<Projectile>().Initialize(parameter);
        return projectile;
    }
}
