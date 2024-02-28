using GameSystem.GameStateMachineSystem;
using UnityEngine;

namespace UI.Labels
{
    public class LevelIncomeLabel : TextSetter
    {
        [SerializeField] private ResultState _resultState;

        private void Start()
        {
            _resultState.Entered += SetIncome;
        }

        private void SetIncome()
        {
            SetText(_resultState.Reward);
            ResizeText();
        }
    }
}