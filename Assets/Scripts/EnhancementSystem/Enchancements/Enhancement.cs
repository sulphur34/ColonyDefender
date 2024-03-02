using System;
using UnityEngine;
using Utils.Interfaces;

namespace EnhancementSystem.Enhancements
{
    public class Enhancement : MonoBehaviour, ISavable
    {
        [SerializeField] private string _token;
        [SerializeField] private float _defaultValue;
        [SerializeField] private float _upgradeStep;

        public event Action<float> ValueChanged;

        public string Token => _token;

        public float CurrentValue { get; private set; }
        public float UpgradeLevel { get; private set; }

        public virtual void Increase()
        {
            SetValue(CurrentValue += _upgradeStep);
            Save();
            UpgradeLevel++;
            ValueChanged?.Invoke(UpgradeLevel);
        }

        public virtual void Reset()
        {
            UpgradeLevel = 0;
            SetValue(_defaultValue);
            ValueChanged?.Invoke(UpgradeLevel);
            Save();
        }

        public virtual bool IsAvailable()
        {
            return true;
        }

        public virtual void Save()
        {
            PlayerPrefs.SetFloat(_token, CurrentValue);
        }

        public virtual void Load()
        {
            if (PlayerPrefs.HasKey(_token))
            {
                CurrentValue = PlayerPrefs.GetFloat(_token);
                UpgradeLevel = Mathf.Round((CurrentValue - _defaultValue) / _upgradeStep);
                ValueChanged?.Invoke(UpgradeLevel);
            }
            else
            {
                Reset();
            }
        }

        private void SetValue(float value)
        {
            CurrentValue = value;
        }
    }
}