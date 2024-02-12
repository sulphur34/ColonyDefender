using System;

public interface IHealth
{
    public event Action Died;
    public event Action HealthChanged;

    public float CurrentHealth { get; }
}
