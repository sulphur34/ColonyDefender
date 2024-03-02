using System.Collections.Generic;
using AudioSystem;
using EnhancementSystem;
using EnhancementSystem.Enhancements;
using GameSystem;
using GameSystem.GameStateMachineSystem;
using UI.Menus;
using UnityEngine;
using Utils.Interfaces;

namespace SaveSystem
{
    public class SaveHandler : MonoBehaviour
    {
        private static SaveHandler _instance;

        [SerializeField] private Enhancement[] _enhancements;
        [SerializeField] private ResourceSystem _resourceSystem;
        [SerializeField] private EnhancementManager _enhancementSystem;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private ResultState[] _resultStates;
        [SerializeField] private EnhancementMenu _enhancementMenu;

        private List<ISavable> _savable;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                Initialize();
                return;
            }

            Destroy(gameObject);
        }

        private void Start()
        {
            LoadAll();
        }

        private void OnDestroy()
        {
            _enhancementMenu.Closed -= SaveAll;

            foreach (ResultState resultState in _resultStates)
            {
                resultState.Exited -= SaveAll;
            }
        }

        public void ResetProgress()
        {
            PlayerPrefs.DeleteAll();
            LoadAll();
        }

        private void SaveAll()
        {
            foreach (ISavable savable in _savable)
            {
                savable.Save();
            }
        }

        private void LoadAll()
        {
            foreach (ISavable savable in _savable)
            {
                savable.Load();
            }
        }

        private void Initialize()
        {
            _savable = new List<ISavable>();

            foreach (Enhancement enhancement in _enhancements)
            {
                _savable.Add(enhancement);
            }

            _savable.Add(_enhancementSystem);
            _savable.Add(_resourceSystem);
            _savable.Add(_audioManager);

            _enhancementMenu.Closed += SaveAll;

            foreach (ResultState resultState in _resultStates)
            {
                resultState.Exited += SaveAll;
            }
        }
    }
}