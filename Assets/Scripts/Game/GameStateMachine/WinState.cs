using System.Collections;
using UnityEngine;

public class WinState : ResultState
{
    [SerializeField] ParticleSystem _winAnimation;

    private Coroutine _coroutine;

    public override void Enter()
    {
        _coroutine = StartCoroutine(PlayWinAnimation());
    }

    public override void Exit() 
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        base.Exit();
    }

    protected override float GenerateReward()
    {
        return _rewardGenerator.GetLevelWinReward();
    }

    private IEnumerator PlayWinAnimation()
    {
        Instantiate(_winAnimation).GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(3f);
        base.Enter();
        float reward = _rewardGenerator.GetLevelWinReward();
        EnhancementSystem.Upgrade<GameLevel>();
    }
}
