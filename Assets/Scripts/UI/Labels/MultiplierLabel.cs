using UI.MultiplierSelector;
using UnityEngine;

namespace UI.Labels
{
    public class MultiplierLabel : TextSetter
    {
        [SerializeField] private MultiplierSelectorUI _selectorUI;
        [SerializeField] private string _prefix;

        private void Start()
        {
            _selectorUI.MultiplierChanged += SetMultiplierMessage;
        }

        private void SetMultiplierMessage(float multiplierValue)
        {
            SetTextWithPrefix(_prefix, multiplierValue);
        }
    }
}