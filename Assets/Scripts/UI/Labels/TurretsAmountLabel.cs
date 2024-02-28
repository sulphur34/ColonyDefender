using GameSystem.GameStateMachineSystem;
using UnityEngine;

namespace UI.Labels
{
    public class TurretsAmountLabel : TextSetter
    {
        [SerializeField] private BuildState _buildState;

        private void Awake()
        {
            _buildState.TurretsAmountChanged += SetText;
            _buildState.Exited += OnBuildFinished;
        }

        private void OnBuildFinished()
        {
            gameObject.SetActive(false);
        }
    }
}