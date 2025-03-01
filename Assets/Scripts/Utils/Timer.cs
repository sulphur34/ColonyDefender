using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        private float _minTime = 0;
        private float _timeFull;
        private float _timerStep = 1f;
        private Coroutine _timerCoroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        public event Action Began;
        public event Action<float> Changed;
        public event Action Ended;

        public float TimeLeft { get; private set; }

        public void Initialize(float time)
        {
            _timeFull = time;
            TimeLeft = _timeFull;
            Changed?.Invoke(TimeLeft);
        }

        public void Begin()
        {
            Began?.Invoke();
            _timerCoroutine = StartCoroutine(CountingDown());
        }

        public void Reset()
        {
            Pause();
            TimeLeft = _timeFull;
            Changed?.Invoke(TimeLeft);
        }

        public void Pause()
        {
            if (_timerCoroutine != null)
                StopCoroutine(_timerCoroutine);
        }

        public void Stop()
        {
            Pause();
            Ended?.Invoke();
        }

        private IEnumerator CountingDown()
        {
            while (TimeLeft > _minTime)
            {
                yield return _waitForSeconds;
                TimeLeft -= _timerStep;
                Changed?.Invoke(TimeLeft);
            }

            Ended?.Invoke();
        }
    }
}