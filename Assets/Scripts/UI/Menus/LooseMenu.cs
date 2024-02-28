using GameSystem.GameStateMachineSystem;
using UnityEngine;

namespace UI.Menus
{
    public class LooseMenu : Menu
    {
        [SerializeField] private LooseState _looseState;

        private void OnEnable()
        {
            _looseState.Entered += Open;
            _looseState.Exited += Close;
        }

        private void OnDisable()
        {
            _looseState.Entered -= Open;
            _looseState.Exited -= Close;
        }
    }
}