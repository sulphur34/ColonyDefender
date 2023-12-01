using System;

public interface IHealth
{
    event Action Died;
    event Action HealthChanged;

    public float CurrentHealth { get; }
}
