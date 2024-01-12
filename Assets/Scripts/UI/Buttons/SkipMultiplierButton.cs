using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkipMultiplierButton : MenuSwitchButton
{
    private float _skipMultiplier = 1;

    public event Action<float> Skipped;

    protected override void Start()
    {
        Button.onClick.AddListener(OnClick);
        base.Start();
    }

    private void OnClick()
    {
        Skipped.Invoke(_skipMultiplier);
    }
}
