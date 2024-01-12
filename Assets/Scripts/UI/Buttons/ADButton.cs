using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ADButton : MonoBehaviour
{
    [SerializeField] private VideoAD _videoAD;

    private Button _button;    

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
        _button.onClick.AddListener(_videoAD.Show);
        _videoAD.RewardGained += OnRewardGained;
        _videoAD.Closed += OnVideoClose;
    }

    protected virtual void OnButtonClick() { }

    protected virtual void OnRewardGained() { }

    protected virtual void OnVideoClose() { }
}
