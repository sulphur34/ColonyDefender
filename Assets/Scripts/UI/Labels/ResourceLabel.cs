using UnityEngine;

public class ResourceLabel : TextSetter
{
    [SerializeField] private ResourceSystem _resourceSystem;

    private void Awake()
    {
        _resourceSystem.AmountChanged += SetText;
    }
}
