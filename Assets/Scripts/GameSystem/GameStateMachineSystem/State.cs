using UnityEngine;
using Utils.Interfaces;

namespace GameSystem.GameStateMachineSystem
{
    public abstract class State : MonoBehaviour
    {
        protected IStateSwitcher Switcher;

        public void Initialize(IStateSwitcher switcher)
        {
            Switcher = switcher;
        }

        public virtual void Enter()
        { }

        public virtual void Exit()
        { }

        public virtual void Run()
        { }
    }
}