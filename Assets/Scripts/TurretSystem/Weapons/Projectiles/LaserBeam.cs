using EnemySystem;

namespace TurretSystem.Weapons.Projectiles
{
    public class LaserBeam : Projectile
    {
        protected override void OnEnemyCollision(Enemy enemy)
        {
            PlayCollisionParticle();
            InflictDamage(enemy);
        }
    }
}