using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : Projectile
{
    protected override void OnEnemyCollision(Enemy enemy)
    {
        base.InflictDamage(enemy);
    }
}
