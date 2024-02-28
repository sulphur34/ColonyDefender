using System;
using System.Collections.Generic;
using Utils.Interfaces;

namespace GameSystem.GameStateMachineSystem
{
    public class StateMachine : IStateSwitcher
    {
        private Dictionary<Type, State> _states;
        private State _currentState;

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

            if (_currentState?.GetType() == type)
                return;

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();
                newState.Enter();
                _currentState = newState;
            }
        }
    }
}