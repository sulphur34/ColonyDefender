public class LooseState : ResultState
{
    public override void Enter()
    {
        base.Enter();
    }

    protected override float GenerateReward()
    {
        return _rewardGenerator.GetLevelLooseReward();
    }
}