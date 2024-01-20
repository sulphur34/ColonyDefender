using System;
using Unity.AI.Navigation;
using UnityEngine;

public class LevelFactory : MonoBehaviour, IFactory<Level>
{
    [SerializeField] private Location[] _locations;
    [SerializeField] private EnemyData[] _enemies;
    [SerializeField] private Barrier barrier;
    [SerializeField] private NavMeshSurface _surface;
    [SerializeField] private WaveFactory _waveFactory;   

    public event Action<Level> Built;

    public Level Build(float levelIndex)
    {
        Location terrain = Instantiate(GetElement(levelIndex, _locations));
        barrier.gameObject.SetActive(false);
        _surface.BuildNavMesh();
        barrier.gameObject.SetActive(true);
        EnemyData enemyData = GetElement(levelIndex, _enemies);
        _waveFactory = new WaveFactory(terrain, enemyData);
        IWave wave = _waveFactory.Build(levelIndex);
        Level level = new Level(terrain, wave);
        Built.Invoke(level);
        return level;
    }

    private T GetElement<T>(float levelIndex, T[] elements)
    {
       int index = GetIndexFromLevel(levelIndex, elements.Length);
       return elements[index];
    }   

    private int GetIndexFromLevel(float levelIndex, int maxIndex)
    {
        int index = Mathf.CeilToInt(levelIndex / maxIndex);
        int firstElement = 0;

        if (index >= maxIndex)
        {
            index = UnityEngine.Random.Range(firstElement, maxIndex);
            return index;
        }

        return index - 1;
    }    
}
