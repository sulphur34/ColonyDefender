using System;
using Unity.AI.Navigation;
using UnityEngine;

public class LevelFactory : MonoBehaviour, IFactory<Level>
{
    [SerializeField] private LocationData[] _locationsData;
    [SerializeField] private EnemyData[] _enemies;
    [SerializeField] private Barrier barrier;
    [SerializeField] private NavMeshSurface _surface;
    [SerializeField] private WaveFactory _waveFactory;

    private int _levelBatchValue = 5;

    public event Action<Level> Built;

    public Level Build(float levelIndex)
    {
        LocationData locationData = GetElement(levelIndex, _locationsData);
        Location location = Instantiate(locationData.Location);
        RenderSettings.skybox = locationData.skyboxMaterial;
        barrier.gameObject.SetActive(false);
        _surface.BuildNavMesh();
        barrier.gameObject.SetActive(true);
        EnemyData enemyData = GetElement(levelIndex, _enemies);
        _waveFactory = new WaveFactory(location, enemyData);
        IWave wave = _waveFactory.Build(levelIndex);
        Level level = new Level(location, wave);
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
        int combinationsIndex = _levelBatchValue * maxIndex;
        int firstElement = 0;
        int index = firstElement;

        if (combinationsIndex < levelIndex)
        {
            index = UnityEngine.Random.Range(firstElement, maxIndex);
        }
        else
        {
            index = Mathf.FloorToInt((levelIndex - 1) % combinationsIndex / _levelBatchValue);
        }

        return index;
    }
}
