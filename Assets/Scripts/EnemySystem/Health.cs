using System;
using Utils.Interfaces;

namespace EnemySystem
{
    public class Health : IHealth, IDamageable
    {
        private readonly float _minValue = 0;
        private float _currentValue;

        public Health(float maxHealth)
        {
            _currentValue = maxHealth;
        }

        public event Action Died;
        public event Action HealthChanged;

        public float CurrentHealth => _currentValue;

        public void TakeDamage(float damage)
        {
            _currentValue = MathF.Max(_minValue, _currentValue - damage);
            HealthChanged?.Invoke();

            if (_currentValue <= _minValue)
                Died?.Invoke();
        }
    }
}
