using EnhancementSystem.Enhancements;

namespace UI.Labels
{
    public class EnhancementLeveLabel : TextSetter
    {
        public void Initialize(Enhancement enhancement)
        {
            enhancement.ValueChanged += SetValue;
        }

        private void SetValue(float value)
        {
            if (value == 0)
                SetText("");
            else
                SetText(value);
        }
    }
}