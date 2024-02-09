using System;
using System.Collections.Generic;
using System.Diagnostics;

public class StateMachine : IStateSwitcher
{
    private Dictionary<Type, State> _states;

    public  State CurrentState { get; private set; }

    public void AddState(State state)
    {
        if (_states == null)
            _states = new Dictionary<Type, State>();

        state.Initialize(this);
        _states.Add(state.GetType(), state);
    }

    public void SwitchState<T>() where T : State
    {
        var type = typeof(T);

        if (CurrentState?.GetType() == type)
            return;

        if(_states.TryGetValue(type, out var newState))
        {
            UnityEngine.Debug.Log("Switch from " + CurrentState?.GetType() + " to " + newState.GetType());
            CurrentState?.Exit();
            newState.Enter();
            CurrentState = newState;
        }
    }

    public void Run()
    {
        CurrentState?.Run();
    }    
}
