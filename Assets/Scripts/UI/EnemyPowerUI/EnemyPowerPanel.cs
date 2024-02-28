using System.Collections.Generic;
using GameSystem;
using UnityEngine;

namespace UI.EnemyPowerUI
{
    [RequireComponent(typeof(Canvas))]
    public class EnemyPowerPanel : MonoBehaviour
    {
        [SerializeField] private EnemyPowerIcon[] _powerIcons;
        [SerializeField] private LevelFactory _levelFactory;

        private IReadOnlyList<float> _powerValues;
        private Canvas _canvas;

        private void Awake()
        {
            _levelFactory.Built += SetPowerInfo;
            _canvas = GetComponent<Canvas>();
            Hide();
        }

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }

        private void SetPowerInfo(Level level)
        {
            _powerValues = level.Wave.RouteData;

            for (int i = 0; i < _powerValues.Count; i++)
            {
                if (_powerValues[i] > 0)
                {
                    _powerIcons[i].Set(Mathf.Round(_powerValues[i]));
                    _powerIcons[i].Show();
                }
                else
                {
                    _powerIcons[i].Hide();
                }
            }
        }
    }
}