using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private LevelIcon[] _levelLabels = new LevelIcon[5];
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private Color _current;
    [SerializeField] private Color _pass;
    [SerializeField] private Color _default;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        int currentLevel = _gameHandler.CurrentLevel;
        int minLevel = _gameHandler.MinLevelInBatch;
        int maxLevel = _gameHandler.MaxLevelInBatch;
        int batchValue = _gameHandler.LevelBatchValue;

        for (int i = 0; i < batchValue; i++)
        {
            int levelValue = i + minLevel;

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
