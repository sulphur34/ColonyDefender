using DG.Tweening;
using UnityEngine;

namespace UI.MultiplierSelector
{
    [RequireComponent(typeof(RectTransform))]
    public class MultiplierArrow : MonoBehaviour
    {
        [SerializeField] private Vector2 _moveOffcet;
        [SerializeField] private float _animationTime = 0.5f;

        private RectTransform _rectTransform;
        private Sequence _sequence;
        private Vector2 _startPosition;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition;
        }

        private void OnDisable()
        {
            _sequence.Kill();
        }

        public void Stop()
        {
            _sequence.Pause();
        }

        public void Play()
        {
            _sequence.Play();
        }

        public void Restart()
        {
            _rectTransform.anchoredPosition = _startPosition;
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(GetTweenAnimation(_startPosition + _moveOffcet));
            _sequence.Append(GetTweenAnimation(_startPosition - _moveOffcet));
            _sequence.SetLoops(-1, LoopType.Restart);
        }

        private Tween GetTweenAnimation(Vector2 destination)
        {
            return _rectTransform.DOAnchorPos(destination, _animationTime)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.Flash);
        }
    }
}