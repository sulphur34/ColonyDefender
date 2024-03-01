using DG.Tweening;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class ScalingUI : MonoBehaviour
    {
        [SerializeField] private Vector2 _scale;
        [SerializeField] private float _duration = 0.5f;

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
            _tween = _transform.DOScale(_scale, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash);
        }

        private void OnDisable()
        {
            _tween.Kill();
            _transform.localScale = _defaultScale;
        }
    }
}