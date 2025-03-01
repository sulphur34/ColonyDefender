using System;

namespace UI.Buttons.ADButtons
{
    public class AddTurretADButton : ADRewardedButton
    {
        public event Action RewardGained;

        protected override void OnButtonClick()
        {
            RewardGained?.Invoke();
        }

        protected override void OnRewardGained()
        {
            gameObject.SetActive(false);
        }

        protected override void OnVideoClose()
        { }
    }
}