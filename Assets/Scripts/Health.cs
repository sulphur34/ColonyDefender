using System;

public class Health : IDamageable
{
    private float _minValue = 0;
    private float _currentValue;

    public Health(float maxHealth)
    {
        _currentValue = maxHealth;
    }

    public event Action Die;

    public void TakeDamage(float damage)
    {
        _currentValue = MathF.Max(_minValue, _currentValue - damage);

        if (_currentValue == _minValue)
            Die.Invoke();
    }
}
