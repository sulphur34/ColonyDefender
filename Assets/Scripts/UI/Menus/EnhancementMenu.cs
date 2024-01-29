
using UnityEngine;

public class EnhancementMenu : Menu
{
    [SerializeField] EnhansementPanel[] _enhansementPanels;

    private void Start()
    {
        Initialize();
        Opened += RefreshValues;
    }

    private void Initialize()
    {
        foreach (EnhansementPanel panel in _enhansementPanels)
        {
            panel.EnhancementPurchased += RefreshValues;
        }
    }

    private void RefreshValues()
    {
        foreach (EnhansementPanel panel in _enhansementPanels)
        {
            panel.SetState();
        }
    }
}
