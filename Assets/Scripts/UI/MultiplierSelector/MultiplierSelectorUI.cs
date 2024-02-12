using System;
using UnityEngine;

public class MultiplierSelectorUI : MonoBehaviour
{
    [SerializeField] private MultiplierField[] _multiplierFields;
    [SerializeField] private MultiplierArrow _multiplierArrow;
    [SerializeField] private ResultState _resultState;

    public event Action<float> MultiplierChanged;

    public float Multiplier { get; private set; }

    private void Start()
    {
        Initialize();
        _resultState.Entered += Activate;
        _resultState.Exited += Deactivate;
    }

    public void Activate()
    {
        _multiplierArrow.Reset();
    }

    public void Stop()
    {
        _multiplierArrow.Stop();
    }
    
    public void Deactivate()
    {
        _multiplierArrow.Stop();
    }

    private void Initialize()
    {
        foreach (MultiplierField field in _multiplierFields)
        {
            field.Entered += SetMultiplier;
        }
    }

    private void SetMultiplier(float multiplier)
    {
        Multiplier = multiplier;
        MultiplierChanged.Invoke(Multiplier);
    }
}
