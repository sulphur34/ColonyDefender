using GameSystem.GameStateMachineSystem;

namespace Utils.Interfaces
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : State;
    }
}