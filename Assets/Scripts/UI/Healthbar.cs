using EnemySystem;
using UnityEngine;
using UnityEngine.UI;
using Utils.Interfaces;

namespace UI
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Image _healthLine;

        private Enemy _enemy;
        private IHealth _health;
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
            _enemy = GetComponentInParent<Enemy>();
            _health = _enemy.Health;
            _health.HealthChanged += OnHealthChanged;
            SetStartValues();
        }

        private void Update()
        {
            _transform.forward = Camera.main.transform.forward;
        }

        private void OnDisable()
        {
            if (_health != null)
                _health.HealthChanged -= OnHealthChanged;
        }

        private void SetStartValues()
        {
            _slider.maxValue = _health.CurrentHealth;
            _slider.value = _health.CurrentHealth;
            _healthLine.color = _gradient.Evaluate(1f);
        }

        private void OnHealthChanged()
        {
            _slider.value = _health.CurrentHealth;
            _healthLine.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }
}