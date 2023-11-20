using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _healthLine;
    [SerializeField] private float _changeStep;

    private Coroutine _coroutine;
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
        _health.HealthChanged -= OnHealthChanged;
    }

    public void SetStartValues()
    {
        _slider.maxValue = _health.CurrentHealth;
        _slider.value = _health.CurrentHealth;
        _healthLine.color = _gradient.Evaluate(1f);
    }

    public void OnHealthChanged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(AnimateHealthChange(_health.CurrentHealth));
    }

    private IEnumerator AnimateHealthChange(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _changeStep * Time.deltaTime);
            _healthLine.color = _gradient.Evaluate(_slider.normalizedValue);
            yield return null;
        }
    }
}
