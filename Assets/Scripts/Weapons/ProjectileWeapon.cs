using System.Collections;
using UnityEngine;

public class ProjectileWeapon : ObjectPool, IWeapon
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _fireDelay;
    [SerializeField] private float _fireForce;

    private WaitForSeconds _delayTime;
    private Coroutine _coroutine;
    private Transform _transform;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_fireDelay);
        Initialize(_projectile);
        _transform = transform;
    }

    public void StartFire()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    public void EndFire()
    {
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
                projectile.GetComponent<Projectile>().ApplyForce(_transform.up * _fireForce);
            }
            yield return _delayTime;
        }
    }
}
