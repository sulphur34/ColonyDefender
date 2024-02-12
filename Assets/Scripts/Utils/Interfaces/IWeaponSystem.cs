using UnityEngine;

public interface IWeaponSystem
{
    public void Initialize(Material material, Weapon weapon, GunScheme gunsPosition, WeaponMultipliers weaponParameters);
    public void Activate(Enemy target);
    public void Deactivate();    
}
