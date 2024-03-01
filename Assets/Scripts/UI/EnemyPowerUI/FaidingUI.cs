using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EnemyPowerUI
{
    [RequireComponent(typeof(Image))]
    public class FadingUI : MonoBehaviour
    {
        [SerializeField] private float _fadeValue = 0.1f;
        [SerializeField] private float _duration = 2f;

        private Image _image;
        private Tween _signalTween;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _signalTween = _image.DOFade(_fadeValue, _duration).SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Flash);
        }

        private void OnDisable()
        {
            _signalTween.Kill();
        }

        public void Show()
        {
            _image.enabled = true;
        }

        public void Hide()
        {
            _image.enabled = false;
        }
    }
}