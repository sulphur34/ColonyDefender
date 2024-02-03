using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent (typeof(VideoAD))]
public abstract class ADButton : MonoBehaviour
{
    private VideoAD _videoAD;
    private Button _button;

    private void Awake()
    {
        _videoAD = GetComponent<VideoAD>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
        _button.onClick.AddListener(_videoAD.Show);
        _videoAD.RewardGained += OnRewardGained;
        _videoAD.Closed += OnVideoClose;
    }

    protected abstract void OnButtonClick();

    protected abstract void OnRewardGained();

    protected abstract void OnVideoClose();
}
