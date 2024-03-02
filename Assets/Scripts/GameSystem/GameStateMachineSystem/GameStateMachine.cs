using UnityEngine;

namespace GameSystem.GameStateMachineSystem
{
    public class GameStateMachine : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            SwitchState<PauseState>();
        }

        public void SwitchState<T>() where T : State
        {
            _stateMachine.SwitchState<T>();
        }

        private void Initialize()
        {
            _stateMachine = new StateMachine();

            foreach (var gameState in GetComponents<GameState>())
            {
                _stateMachine.AddState(gameState);
            }
        }
    }
}