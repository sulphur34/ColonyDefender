using System.Collections;
using UnityEngine;

public class LooseState : ResultState
{
    [SerializeField] private BurstWave _burstWave;

    private Coroutine _coroutine;

    public override void Enter()
    {
        _coroutine = StartCoroutine(PlayLooseAnimation());
    }

    public override void Exit()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        base.Exit();
    }

    protected override float GenerateReward()
    {
        return _rewardGenerator.GetLevelLooseReward();
    }

    private IEnumerator PlayLooseAnimation()
    {
        _burstWave.PlayParticle();
        yield return new WaitForSeconds(3f);
        base.Enter();
    }
}