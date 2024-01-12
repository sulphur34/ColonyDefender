using UnityEngine;

public class BuildingTimerLabel : TextSetter
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _runningOutColor;

    private int _timerAlarmThreshold = 5;

    private void Awake()
    {
        _timer.Began += Enable;
        _timer.Changed += OnTimerChange;
        _timer.Ended += Disable;
    }

    private void OnTimerChange(float timerValue)
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
