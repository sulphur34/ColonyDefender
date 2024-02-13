using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ScailingUI : MonoBehaviour
{
    [SerializeField] private Vector2 _scale;

    private RectTransform _transform;
    private Tween _tween;
    private Vector3 _defaultScale;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _defaultScale = _transform.localScale;
    }

    private void OnEnable()
    {
        _tween = _transform.DOScale(_scale, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash);
    }

    private void OnDisable()
    {
        _tween.Kill();
        _transform.localScale = _defaultScale;
    }
}
