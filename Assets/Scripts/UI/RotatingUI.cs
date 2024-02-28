using DG.Tweening;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class RotatingUI : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationStep;

        private RectTransform _transform;
        private Tween _tween;
        private Quaternion _defaultRotation;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _defaultRotation = _transform.rotation;
        }

        private void OnEnable()
        {
            _tween = _transform.DOLocalRotate(_transform.rotation.eulerAngles + _rotationStep, 0.5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Flash);
        }

        private void OnDisable()
        {
            _tween.Kill();
            _transform.rotation = _defaultRotation;
        }
    }
}