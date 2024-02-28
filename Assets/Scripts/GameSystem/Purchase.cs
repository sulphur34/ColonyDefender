using EnhancementSystem.Enhancements;
using System;
using UnityEngine;

namespace GameSystem
{
    public class Purchase : MonoBehaviour
    {
        [SerializeField] private float _baseCost;
        [SerializeField] private float _costUpgradeMultiplier;

        private ResourceSystem _resourceSystem;
        private Enhancement _enhancement;

        public event Action Completed;

        public float CurrentCost => GetCurrentCost();
        public bool CanBuy => _enhancement.IsAvailable()
            && _resourceSystem.IsAffordable(CurrentCost);

        public void Initialize(ResourceSystem resourceSystem, Enhancement enhancement)
        {
            _resourceSystem = resourceSystem;
            _enhancement = enhancement;
        }

        public bool TryBuy()
        {
            if (CanBuy)
            {
                _resourceSystem.Withdraw(this);
                _enhancement.Increase();
                Completed?.Invoke();
                return true;
            }

            return false;
        }

        private float GetCurrentCost()
        {
            return MathF.Round(_baseCost *
                Mathf.Pow(_costUpgradeMultiplier, _enhancement.UpgradeLevel));
        }
    }
}
