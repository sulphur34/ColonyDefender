using System;

public interface IDamageable
{
    event Action Die;

    void TakeDamage(float damage);
}
