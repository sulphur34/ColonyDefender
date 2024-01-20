using UnityEngine;

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

    private void Initialize()
    {
        _stateMachine = new StateMachine();

        foreach (var gameState in GetComponents<GameState>())
        {
            _stateMachine.AddState(gameState);
        }
    }

    public void SwitchState<T>() where T : State
    {
        _stateMachine.SwitchState<T>();
    }    
}
