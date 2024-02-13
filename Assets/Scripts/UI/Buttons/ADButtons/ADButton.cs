using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(VideoAD))]
public abstract class ADButton : MonoBehaviour
{
    protected VideoAD VideoAD;
    private Button _button;

    protected virtual void Awake()
    {
        VideoAD = GetComponent<VideoAD>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
        _button.onClick.AddListener(ShowAD);
        VideoAD.Closed += OnVideoClose;
    }

    protected abstract void ShowAD();

    protected abstract void OnButtonClick();

    protected abstract void OnVideoClose();
}
