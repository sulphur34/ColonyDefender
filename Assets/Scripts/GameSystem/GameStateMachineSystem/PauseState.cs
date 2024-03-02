namespace GameSystem.GameStateMachineSystem
{
    public class PauseState : GameState
    {
        public Level Level { get; private set; }

        public override void Enter()
        {
            base.Enter();
            Level?.Clear();
        }

        public override void Exit()
        {
            base.Exit();
            Level = LevelFactory.Build(EnhancementSystem.GameLevelValue);
        }
    }
}