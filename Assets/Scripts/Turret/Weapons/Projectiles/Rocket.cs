using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
public class RocketTurret : Projectile
{
    private readonly float _damageRadius = 4f;
    private MeshRenderer _meshRenderer;

    protected override void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer> ();
        base.Awake();
    }

    protected override void OnEnable()
    {
        _meshRenderer.enabled = true;
        base.OnEnable();
    }

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

    protected override void DisableOnEnemyCollision()
    {
        _meshRenderer.enabled = false;
        base.DisableOnEnemyCollision();
    }
}
