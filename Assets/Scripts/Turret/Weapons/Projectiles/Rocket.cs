using UnityEngine;

public class RocketTurret : Projectile
{
    private readonly float _damageRadius = 20f;

    protected override void InflictDamage(Enemy enemy)
    {
        base.InflictDamage(enemy);
        Collider[] colliders = Physics.OverlapSphere(CurrentPosition, _damageRadius);

        foreach (Collider collider in colliders)
        {
            if(TryGetEnemy(collider, out Enemy otherEnemy))
                base.InflictDamage(otherEnemy);
        }
    }
}
