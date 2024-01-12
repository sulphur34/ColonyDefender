using System;
using UnityEngine;
using DG.Tweening;

public class MultiplierField : MonoBehaviour
{
    [SerializeField] private Transform _labelTransform;
    [SerializeField] private float _multiplier;
    [SerializeField] private float _scaleFactor = 2f;
    [SerializeField] private float _animationTime = 0.2f;

    private Tween _scaleTween;
    private Vector3 _defaultScale;

    public event Action<float> Entered;

    private void Awake()
    {
        _defaultScale = _labelTransform.localScale;
    }

    private void OnDisable()
    {
        _scaleTween?.Kill();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entered.Invoke(_multiplier);
        _scaleTween?.Kill();
        _scaleTween = _labelTransform.DOScale(_defaultScale * _scaleFactor, _animationTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _scaleTween?.Kill();
        _scaleTween = _labelTransform.DOScale(_defaultScale, _animationTime);
    }
}
