using EnhancementSystem.Enhancements;

namespace UI.Labels
{
    public class EnhancementLeveLabel : TextSetter
    {
        public void Initialize(Enhancement enhancement)
        {
            enhancement.ValueChanged += SetText;
        }
    }
}