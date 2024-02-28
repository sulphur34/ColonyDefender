using TurretSystem;
using TurretSystem.Weapons;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Turrets Data", fileName = "new turret data", order = 56)]
    public class TurretData : ScriptableObject
    {
        [SerializeField] private Turret _turretPrefab;
        [SerializeField] private Weapon _weaponPrefab;

        [SerializeField] private GunScheme[] _activeGunsSchemes;

        [SerializeField] private float _damage;
        [SerializeField] private float _fireRate;

        public Turret TurretPrefab => _turretPrefab;
        public Weapon WeaponPrefab => _weaponPrefab;
        public GunScheme[] GunsSchemes => _activeGunsSchemes;
        public float BaseDamage => _damage;
        public float BaseFireRate => _fireRate;
        public float FireRate => _fireRate;
    }
}