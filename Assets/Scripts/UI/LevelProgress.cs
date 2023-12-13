using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private LevelIcon[] _levelLabels = new LevelIcon[5];
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private Color _current;
    [SerializeField] private Color _pass;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        int currentLevel = _gameHandler.CurrentLevel;
        int minLevel = _gameHandler.MinLevelInBatch;
        int maxLevel = _gameHandler.MaxLevelInBatch;

        for (int i = 0; i < maxLevel; i++)
        {
            int levelValue = i + minLevel;

            _levelLabels[i].SetText(levelValue.ToString());

            if (levelValue < currentLevel)
                _levelLabels[i].SetColor(_pass);
            else if (levelValue == currentLevel)
                _levelLabels[i].SetColor(_current);
        }
    }
}
