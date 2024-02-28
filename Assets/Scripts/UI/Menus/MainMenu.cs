using GameSystem.GameStateMachineSystem;
using UI.LevelProgressUI;
using UnityEngine;

namespace UI.Menus
{
    public class MainMenu : Menu
    {
        [SerializeField] private PauseState _pauseState;
        [SerializeField] private LevelProgressPanel _levelProgressUI;

        private void OnEnable()
        {
            _pauseState.Entered += Open;
            _pauseState.Exited += Close;
        }

        private void OnDisable()
        {
            _pauseState.Entered -= Open;
            _pauseState.Exited -= Close;
        }

        public override void Open()
        {
            base.Open();
            _levelProgressUI.ResetPanel();
        }
    }
}