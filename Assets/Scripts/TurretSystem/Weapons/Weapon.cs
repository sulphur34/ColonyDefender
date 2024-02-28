using System.Collections;
using TurretSystem.Weapons.Projectiles;
using UnityEngine;
using Utils.Interfaces;

namespace TurretSystem.Weapons
{
    public class Weapon : ObjectPool, IWeapon
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private float _fireForce;
        [SerializeField] private float _fireRate;

        private WaitForSeconds _delayTime;
        private Coroutine _coroutine;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnDestroy()
        {
            Clear();
        }

        public void Initialize(float damageMultiplier, float fireRateMultiplier)
        {
            _fireRate = _fireRate / fireRateMultiplier;
            _delayTime = new WaitForSeconds(_fireRate);
            Initialize(_projectile, damageMultiplier);
        }

        public void StartFire()
        {
            _coroutine = StartCoroutine(Shooting());
        }

        public void EndFire()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        protected override GameObject GetObjectWithParameter<T>(T prefab, float parameter)
        {
            GameObject projectile = Instantiate(prefab.gameObject);
            projectile.GetComponent<Projectile>().Initialize(parameter);
            return projectile;
        }

        private IEnumerator Shooting()
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
    }
}