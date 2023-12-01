using UnityEngine;

public class TurretFactory : MonoBehaviour, IFactory<Turret>
{
    [SerializeField] private TurretData[] _turretsData;
    [SerializeField] private Material[] _materials;
    [SerializeField] private EnhancementSystem _enhancementSystem;
    [SerializeField] private EnemyTrackSystem _enemyTrackSystem;
        
    public Turret Build(int turretLevel)
    {
        UpgradeIndex upgradeIndex =
            new UpgradeIndex(turretLevel, _turretsData.Length, _materials.Length,
            _turretsData[0].GunsSchemes.Length);
        TurretData currentTurretData = _turretsData[upgradeIndex.TurretIndex];
        Turret turret = Instantiate(currentTurretData.TurretPrefab);
        turret.Initialize(_enemyTrackSystem, turretLevel);

        Material material = _materials[upgradeIndex.GradeIndex];
        GunScheme gunsPositions = currentTurretData.GunsSchemes[upgradeIndex.GunsIndex];
        WeaponMultipliers weaponParameters = GetWeaponMultipliers(upgradeIndex);
        turret.WeaponSystem.Initialize(material, currentTurretData.WeaponPrefab, gunsPositions, weaponParameters);

        return turret;
    }

    private WeaponMultipliers GetWeaponMultipliers(UpgradeIndex upgradeIndex)
    {
        float fireRate = _enhancementSystem.FireRateMultiplier;
        float damageMultiplier = _enhancementSystem.DamageMultiplier + upgradeIndex.DamageMultiplier;
        return new WeaponMultipliers(fireRate, damageMultiplier);
    }    
}