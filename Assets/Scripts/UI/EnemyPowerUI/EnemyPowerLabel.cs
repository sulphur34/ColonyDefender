using UI.Labels;

namespace UI.EnemyPowerUI
{
    public class EnemyPowerLabel : TextSetter
    {
        public void SetPowerValue(float powerValue)
        {
            SetText(powerValue);
        }
    }
}