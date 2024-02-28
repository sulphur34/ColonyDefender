using UnityEngine;

namespace UI.Menus
{
    public class TrainingMenu : Menu
    {
        [SerializeField] private ExplanationPanel[] _explanationPanels;

        public override void Open()
        {
            base.Open();
            _explanationPanels[0].Open();
        }

        public override void Close()
        {
            CloseAllPanels();
            base.Close();
        }

        private void CloseAllPanels()
        {
            foreach (var panel in _explanationPanels)
            {
                panel.Close();
            }
        }
    }
}