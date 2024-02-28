using System.Linq;
using UI.EnemyPowerUI;
using UI.Labels;
using UI.Menus;
using UnityEngine;

namespace UI.Buttons
{
    public class EnhancementMenuButton : MenuSwitchButton
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private EnhansementPanel[] _enhancementPanels;
        [SerializeField] private ScalingUI _scailingArrow;
        [SerializeField] private FadingUI _signalArrow;

        private void OnEnable()
        {
            _mainMenu.Opened += SetState;
        }

        private void OnDisable()
        {
            _mainMenu.Opened -= SetState;
        }

        private void SetState()
        {
            if (CanBuy())
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
}