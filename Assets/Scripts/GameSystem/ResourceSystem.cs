using SaveSystem;
using System;
using UnityEngine;
using Utils.Interfaces;

namespace GameSystem
{
    public class ResourceSystem : MonoBehaviour, ISavable
    {
        [SerializeField] private float _availableResourcesValue;

        public event Action<float> AmountChanged;

        public string Token => Tokens.AvailableResources;

        private void Awake()
        {
            AmountChanged?.Invoke(_availableResourcesValue);
        }

        public void Withdraw(Purchase purchase)
        {
            _availableResourcesValue -= purchase.CurrentCost;
            AmountChanged?.Invoke(_availableResourcesValue);
            Save();
        }

        public bool IsAffordable(float withdrawalValue)
        {
            return _availableResourcesValue >= withdrawalValue;
        }

        public void Add(float rewardValue)
        {
            _availableResourcesValue += rewardValue;
            AmountChanged?.Invoke(_availableResourcesValue);
            Save();
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(Tokens.AvailableResources, _availableResourcesValue);
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(Tokens.AvailableResources))
                Add(PlayerPrefs.GetFloat(Tokens.AvailableResources));
            else
                _availableResourcesValue = 0;
        }
    }
}
