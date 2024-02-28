using UI.Labels;
using UnityEngine;

namespace UI.Menus
{
    public class EnhancementMenu : Menu
    {
        [SerializeField] private EnhansementPanel[] _enhancementPanels;

        private void Start()
        {
            Initialize();
            Opened += RefreshValues;
        }

        private void Initialize()
        {
            foreach (EnhansementPanel panel in _enhancementPanels)
            {
                panel.EnhancementPurchased += RefreshValues;
            }
        }

        private void RefreshValues()
        {
            foreach (EnhansementPanel panel in _enhancementPanels)
            {
                panel.SetState();
            }
        }
    }
}