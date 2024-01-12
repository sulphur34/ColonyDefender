using UnityEngine;

public interface IWeaponSystem
{
    void Initialize(Material material, Weapon weapon, GunScheme gunsPosition, WeaponMultipliers weaponParameters);
    void Activate(Transform target);
    void Deactivate();    
}
