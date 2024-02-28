using EnhancementSystem;
using EnhancementSystem.Enhancements;
using UnityEngine;
using Utils;

namespace UI.LevelProgressUI
{
    public class LevelProgressPanel : MonoBehaviour
    {
        [SerializeField] private LevelIcon[] _levelLabels = new LevelIcon[5];
        [SerializeField] private Enhancement _gameLevel;
        [SerializeField] private EnhancementManager _enhancementSystem;
        [SerializeField] private Color _current;
        [SerializeField] private Color _pass;
        [SerializeField] private Color _default;

        private void Start()
        {
            ResetPanel();
            _gameLevel.ValueChanged += SetValues;
        }

        public void ResetPanel()
        {
            SetValues(_gameLevel.CurrentValue);
        }

        private void SetValues(float currentLevel)
        {
            float batchValue = _enhancementSystem.LevelBatchValue;
            Range levelRange = RangeCalculator.GetRangeByDivider(currentLevel, batchValue);

            for (int i = 0; i < batchValue; i++)
            {
                float levelValue = i + levelRange.Minimum;

                _levelLabels[i].SetText(levelValue.ToString());

                if (levelValue < currentLevel)
                    _levelLabels[i].SetColor(_pass);
                else if (levelValue == currentLevel)
                    _levelLabels[i].SetColor(_current);
                else
                    _levelLabels[i].SetColor(_default);
            }
        }
    }
}