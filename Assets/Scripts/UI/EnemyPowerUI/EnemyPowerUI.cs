using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class EnemyPowerUI : MonoBehaviour
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
                _powerIcons[i].Hide();
        }
    }

    public void Show()
    {
        _canvas.enabled = true;
    }

    public void Hide()
    {
        _canvas.enabled = false;
    }
}
