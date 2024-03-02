using System.Collections.Generic;
using EnhancementSystem.Enhancements;
using SaveSystem;
using TurretSpawnSystem.CellSystem;
using UnityEngine;
using Utils.Interfaces;

namespace EnhancementSystem
{
    public class EnhancementManager : MonoBehaviour, ISavable
    {
        [SerializeField] private Dictionary<string, Enhancement> _enhancements;
        [SerializeField] private float _levelBatchValue = 5;
        [SerializeField] private string _token;

        public float FireRateValue => Get(Tokens.FireRateUpgrade).CurrentValue;
        public float DamageValue => Get(Tokens.DamageUpgrade).CurrentValue;
        public float ResourcesIncomeValue => Get(Tokens.ResourceIncomeUpgrade).CurrentValue * GameLevelValue;
        public float BuiltTimeValue => Get(Tokens.BuildTimeUpgrade).CurrentValue;
        public float BaseTurretLevelValue => Get(Tokens.BaseTurretLevel).CurrentValue;
        public float GameLevelValue => Get(Tokens.ProgressLevel).CurrentValue;
        public float LevelBatchValue => _levelBatchValue;
        public float MaxTurretLevelValue { get; private set; }
        public string Token => _token;

        private void Awake()
        {
            Initialize();
        }

        public void ResetManager()
        {
            foreach (KeyValuePair<string, Enhancement> enhancement in _enhancements)
            {
                enhancement.Value.Reset();
            }
        }

        public void SetMaxTurretLevel(CellBoard cellBoard)
        {
            MaxTurretLevelValue = cellBoard.MaxTurretLevel;
            Save();
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(Tokens.MaxTurretBuilt, MaxTurretLevelValue);
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(Tokens.MaxTurretBuilt))
                MaxTurretLevelValue = PlayerPrefs.GetFloat(Tokens.MaxTurretBuilt);
            else
                MaxTurretLevelValue = 0;
        }

        public void Upgrade(string token)
        {
            Enhancement enhancement = Get(token);
            enhancement?.Increase();
        }

        private void Initialize()
        {
            _enhancements = new Dictionary<string, Enhancement>();

            foreach (var enhancement in GetComponents<Enhancement>())
            {
                _enhancements.Add(enhancement.Token, enhancement);
            }
        }

        private Enhancement Get(string token)
        {
            return _enhancements.TryGetValue(token, out Enhancement enhancement) ? enhancement : null;
        }
    }
}