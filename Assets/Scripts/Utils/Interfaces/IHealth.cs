using System;

namespace Utils.Interfaces
{
    public interface IHealth
    {
        public event Action Died;
        public event Action HealthChanged;

        public float CurrentHealth { get; }
    }
}