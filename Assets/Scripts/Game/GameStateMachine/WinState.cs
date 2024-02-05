using System.Collections;
using UnityEngine;

public class WinState : ResultState
{
    [SerializeField] ParticleSystem _winAnimation;
    [SerializeField] YandexLeaderboard _leaderboard;

    private Coroutine _coroutine;

    public override void Enter()
    {
        _coroutine = StartCoroutine(PlayWinAnimation());
    }

    public override void Exit() 
    {
        _leaderboard.SetPLayerScore(Mathf.RoundToInt(EnhancementSystem.GameLevelValue));

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
