using UnityEngine;

public class EnhancementLeveLabel : TextSetter
{
    public void Initialize(Enhancement enhancement)
    {
        enhancement.ValueChanged += SetText;
    }
}
