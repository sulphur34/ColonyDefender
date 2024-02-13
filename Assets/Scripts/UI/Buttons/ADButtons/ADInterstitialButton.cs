using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(VideoAD))]
public class ADInterstitialButton : ADButton
{
    protected override void OnButtonClick() {}

    protected override void OnVideoClose() {}

    protected override void ShowAD()
    {
        VideoAD.ShowInter();
    }
}
