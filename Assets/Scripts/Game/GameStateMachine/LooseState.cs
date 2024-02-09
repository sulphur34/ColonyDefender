using System.Collections;
using UnityEngine;

public class LooseState : ResultState
{
    [SerializeField] private BurstWave _burstWave;
    
    public override void Enter()
    {
        _coroutine = StartCoroutine(PlayAnimation());
    }

    protected override float GenerateReward()
    {
        return _rewardGenerator.GetLevelLooseReward();
    }

    protected override IEnumerator PlayAnimation()
    {
        _burstWave.PlayParticle();
        yield return WaitForSeconds;
        base.Enter();
    }
}