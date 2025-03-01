using System.Collections;
using UI.Buttons;
using UI.Buttons.ADButtons;
using UnityEngine;

namespace GameSystem.GameStateMachineSystem
{
    public abstract class ResultState : GameState
    {
        [SerializeField] private ResourceSystem _resourceSystem;
        [SerializeField] private LevelEndADButton _aDButton;
        [SerializeField] private SkipMultiplierButton _skipButton;

        protected WaitForSeconds WaitForSeconds;
        protected RewardGenerator _rewardGenerator;
        protected Coroutine _coroutine;
        private float _animationDelay = 2f;

        public float Reward { get; protected set; }

        private void Awake()
        {
            WaitForSeconds = new WaitForSeconds(_animationDelay);
        }

        private void Start()
        {
            _rewardGenerator = new RewardGenerator(EnhancementSystem);
            _aDButton.RewardGained += MultiplyReward;
            _skipButton.Skipped += MultiplyReward;
        }

        public override void Enter()
        {
            Reward = GenerateReward();
            _resourceSystem.Add(Reward);
            base.Enter();
        }

        public override void Exit()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _resourceSystem.Add(Reward);
            base.Exit();
        }

        protected abstract float GenerateReward();

        protected abstract IEnumerator PlayAnimation();

        private void MultiplyReward(float multiplier)
        {
            Reward *= multiplier - 1;
            Switcher.SwitchState<PauseState>();
        }
    }
}