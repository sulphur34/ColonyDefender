public interface IStateSwitcher
{
    void SwitchState<T>() where T : State;
}
