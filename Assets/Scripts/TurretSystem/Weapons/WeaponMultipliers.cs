namespace TurretSystem.Weapons
{
    public struct WeaponMultipliers
    {
        public WeaponMultipliers(float fireRate, float damage)
        {
            FireRate = fireRate;
            Damage = damage;
        }

        public float FireRate { get; private set; }
        public float Damage { get; private set; }
    }
}