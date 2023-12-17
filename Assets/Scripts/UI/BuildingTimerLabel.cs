using UnityEngine;

public class BuildingTimerLabel : TextSetter
{
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _runningOutColor;

    private int _timerAlarmThreshold = 5;

    private void Awake()
    {
        _gameHandler.TimerChange += OnTimerChange;
        _gameHandler.BaseBuilt += Disable;
        _gameHandler.Started += Enable;
    }

    private void OnTimerChange(int timerValue)
    {        
        SetText(timerValue);

        if (timerValue < _timerAlarmThreshold) 
            SetColor(_runningOutColor);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Enable()
    {
        SetColor(_defaultColor);
        gameObject.SetActive(true);
    }
}
