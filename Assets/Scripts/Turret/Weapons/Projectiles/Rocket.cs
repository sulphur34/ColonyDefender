using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    private float _damageRadius = 20f;

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
