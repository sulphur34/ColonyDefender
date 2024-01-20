using UnityEngine;

public class LevelProgressUI : MonoBehaviour
{
    [SerializeField] private LevelIcon[] _levelLabels = new LevelIcon[5];
    [SerializeField] private EnhancementSystem _enhancementSystem;
    [SerializeField] private Color _current;
    [SerializeField] private Color _pass;
    [SerializeField] private Color _default;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        float currentLevel = _enhancementSystem.GameLevelValue;
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
