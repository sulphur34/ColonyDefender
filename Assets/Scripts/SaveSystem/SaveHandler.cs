using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    [SerializeField] private Enhancement[] _enhancements;
    [SerializeField] private ResourceSystem _resourceSystem;
    [SerializeField] private EnhancementSystem _enhancementSystem;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private ResultState[] _resultStates;
    [SerializeField] private EnhancementMenu _enhancementMenu;


    private static SaveHandler _instance;
    private List<ISaveable> _saveables;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Initialize();
            return;
        }

        Destroy(this.gameObject);
    }

    private void Start()
    {
        LoadAll();
    }

    public void SaveAll()
    {
        foreach (ISaveable savable in _saveables)
        {
            savable.Save();
        }
    }

    public void LoadAll()
    {
        foreach (ISaveable savable in _saveables)
        {
            savable.Load();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        LoadAll();
    }
    
    private void Initialize()
    {
        _saveables = new List<ISaveable>();

        foreach (Enhancement enhancement in _enhancements)
        {
            _saveables.Add(enhancement);
        }

        _saveables.Add(_enhancementSystem);
        _saveables.Add(_resourceSystem);
        _saveables.Add(_audioManager);
        _enhancementMenu.Closed += SaveAll;

        foreach (ResultState resultState in _resultStates)
        {
            resultState.Exited += SaveAll;
        }
    }
}
