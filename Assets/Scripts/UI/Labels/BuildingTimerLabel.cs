using UnityEngine;
using Utils;

namespace UI.Labels
{
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
            float secondsInMinute = 60;
            string minutes = Mathf.RoundToInt(timerValue / secondsInMinute).ToString();
            string seconds = (timerValue % secondsInMinute).ToString();
            string timerMessage = minutes + ":" + new string('0', (2 - seconds.Length)) + seconds;
            SetText(timerMessage);

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
}