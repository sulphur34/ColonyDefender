using System.Linq;
using UnityEngine;

public class EnhancementMenuButton : MenuSwitchButton
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private EnhansementPanel[] _enhancementPanels;
    [SerializeField] private ScailingArrow _scailingArrow;
    [SerializeField] private SignalArrow _signalArrow;

    private void OnEnable()
    {
        _mainMenu.Opened += SetState;
    }

    private void OnDisable()
    {
        
    }

    private void SetState()
    {
        if(CanBuy())
        {
            _scailingArrow.enabled = true; 
            _signalArrow.Show();
        }
        else
        {
            _scailingArrow.enabled = false;
            _signalArrow.Hide();
        }
    }

    private bool CanBuy()
    {
        return _enhancementPanels.Any(panel => panel.CanBuy);
    }
}
