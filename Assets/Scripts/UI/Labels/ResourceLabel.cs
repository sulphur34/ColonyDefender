using GameSystem;
using UnityEngine;

namespace UI.Labels
{
    public class ResourceLabel : TextSetter
    {
        [SerializeField] private ResourceSystem _resourceSystem;

        private void Awake()
        {
            _resourceSystem.AmountChanged += SetText;
        }
    }
}