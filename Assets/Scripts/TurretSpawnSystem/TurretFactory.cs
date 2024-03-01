using EnhancementSystem;
using ScriptableObjects;
using TurretSystem;
using TurretSystem.Weapons;
using UnityEngine;
using Utils.Interfaces;

namespace TurretSpawnSystem
{
    public class TurretFactory : MonoBehaviour, IFactory<Turret>
    {
        [SerializeField] private TurretData[] _turretsData;
        [SerializeField] private Material[] _materials;
        [SerializeField] private EnhancementManager _enhancementSystem;
        [SerializeField] private EnemyTrackSystem _enemyTrackSystem;

        public Turret Build(float turretLevel)
        {
            UpgradeIndex upgradeIndex =
                new UpgradeIndex(turretLevel,
                _turretsData.Length,
                _materials.Length,
                _turretsData[0].GunsSchemes.Length);
            TurretData currentTurretData = _turretsData[upgradeIndex.TurretIndex];
            Turret turret = Instantiate(currentTurretData.TurretPrefab);
            turret.Initialize(_enemyTrackSystem, turretLevel);

            Material material = _materials[upgradeIndex.GradeIndex];
            GunScheme gunsPositions = currentTurretData.GunsSchemes[upgradeIndex.GunsIndex];
            WeaponMultipliers weaponMultipliers = GetWeaponMultipliers(upgradeIndex);
            turret.WeaponSystem.Initialize(material, currentTurretData.WeaponPrefab, gunsPositions, weaponMultipliers);

            return turret;
        }

        private WeaponMultipliers GetWeaponMultipliers(UpgradeIndex upgradeIndex)
        {
            float fireRate = _enhancementSystem.FireRateValue;
            float damageMultiplier = _enhancementSystem.DamageValue * upgradeIndex.DamageMultiplier;
            return new WeaponMultipliers(fireRate, damageMultiplier);
        }
    }
}