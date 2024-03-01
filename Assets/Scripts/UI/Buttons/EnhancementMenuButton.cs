using System.Linq;
using UI.EnemyPowerUI;
using UI.Labels;
using UI.Menus;
using UnityEngine;

namespace UI.Buttons
{
    [RequireComponent(typeof(ScalingUI))]
    public class EnhancementMenuButton : MenuSwitchButton
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private EnhansementPanel[] _enhancementPanels;
        [SerializeField] private ScalingUI _scalingArrow;
        [SerializeField] private FadingUI _signalArrow;

        private ScalingUI _scalingUI;

        protected override void Awake()
        {
            base.Awake();
            _scalingUI = GetComponent<ScalingUI>();
        }

        private void OnEnable()
        {
            _mainMenu.Opened += SetState;
        }

        protected override void Start()
        {
            base.Start();
            SetState();
        }

        private void OnDisable()
        {
            _mainMenu.Opened -= SetState;
        }

        private void SetState()
        {
            if (CanBuy())
            {
                _scalingUI.enabled = true;
                _scalingArrow.enabled = true;
                _signalArrow.Show();
            }
            else
            {
                _scalingUI.enabled = false;
                _scalingArrow.enabled = false;
                _signalArrow.Hide();
            }
        }

        private bool CanBuy()
        {
            return _enhancementPanels.Any(panel => panel.CanBuy);
        }
    }
}