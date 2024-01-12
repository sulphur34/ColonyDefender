using System;
using UnityEngine;

public class LevelEndADButton : ADButton
{
    [SerializeField] private MultiplierSelectorUI _selectorUI;
    [SerializeField] private MenuSwitcher _menuSwitcher;

    private float _multiplier;

    public event Action<float> RewardGained;
       
    protected override void OnButtonClick()
    {
        _multiplier = _selectorUI.Multiplier;
        _selectorUI.Deactivate();
    }

    protected override void OnRewardGained()
    {
        RewardGained.Invoke(_multiplier);
        _menuSwitcher.Switch();
    }

    protected override void OnVideoClose()
    {
        _selectorUI.Activate();
    }
}