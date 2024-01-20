using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class SignalArrow : MonoBehaviour
{
    private Image _image;
    private Tween _signalTween;
    private float _fadeValue = 0f;
    private float _duration = 1f;

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
