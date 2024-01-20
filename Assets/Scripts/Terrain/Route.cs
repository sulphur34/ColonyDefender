using System.Linq;
using UnityEngine;

public class Route : MonoBehaviour, IRoute
{
    [SerializeField] private Transform[] _waypoints;

    private int _currentIndex;
    
    public Vector3 SpawnPoint { get; private set; }

    void Awake()
    {
        _currentIndex = 0;
        SpawnPoint = _waypoints[_currentIndex].position;
    }

    public Vector3 GetNextPoint()
    {
        if(_currentIndex < _waypoints.Length - 1) 
        {
            _currentIndex++;
            return _waypoints[_currentIndex].position;
        }

        return _waypoints.Last().position;
    }
}
