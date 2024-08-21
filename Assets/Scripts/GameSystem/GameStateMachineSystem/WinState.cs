using System.Collections;
using LeaderboardSystem;
using SaveSystem;
using UnityEngine;

namespace GameSystem.GameStateMachineSystem
{
    public class WinState : ResultState
    {
        [SerializeField] private ParticleSystem _winAnimation;
        //[SerializeField] private YandexLeaderboard _leaderboard;

        public override void Enter()
        {
            _coroutine = StartCoroutine(PlayAnimation());
        }

        public override void Exit()
        {
            //_leaderboard.SetPLayerScore(Mathf.RoundToInt(EnhancementSystem.GameLevelValue));
            base.Exit();
        }

        protected override float GenerateReward()
        {
            return _rewardGenerator.GetLevelWinReward();
        }

        protected override IEnumerator PlayAnimation()
        {
            EnhancementSystem.Upgrade(Tokens.ProgressLevel);
            ParticleSystem animation = Instantiate(_winAnimation).GetComponent<ParticleSystem>();
            animation.Play();
            yield return WaitForSeconds;
            Destroy(animation.gameObject);
            base.Enter();
        }
    }
}