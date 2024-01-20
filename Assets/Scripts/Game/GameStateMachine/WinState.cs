public class WinState : ResultState
{
    public override void Enter()
    {
        base.Enter();
        float reward = _rewardGenerator.GetLevelWinReward();
        EnhancementSystem.SetMaxTurretLevel(CellBoard);
        EnhancementSystem.Upgrade<GameLevel>();
    }

    public override void Exit() 
    {        
        base.Exit();
    }

    protected override float GenerateReward()
    {
        return _rewardGenerator.GetLevelWinReward();
    }
}
