public class LaserBeam : Projectile
{
    protected override void OnEnemyCollision(Enemy enemy)
    {
        PlayCollisionParticle();
        base.InflictDamage(enemy);
    }
}
