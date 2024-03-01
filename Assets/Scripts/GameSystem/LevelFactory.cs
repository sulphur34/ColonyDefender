using System;
using ScriptableObjects;
using Terrain;
using Unity.AI.Navigation;
using UnityEngine;
using Utils.Interfaces;
using WaveSystem;

namespace GameSystem
{
    public class LevelFactory : MonoBehaviour, IFactory<Level>
    {
        [SerializeField] private LocationData[] _locationsData;
        [SerializeField] private EnemyData[] _enemies;
        [SerializeField] private Barrier _barrier;
        [SerializeField] private NavMeshSurface _surface;
        [SerializeField] private WaveFactory _waveFactory;

        private int _levelBatchValue = 5;

        public event Action<Level> Built;

        public Level Build(float levelIndex)
        {
            LocationData locationData = GetElement(levelIndex, _locationsData, false);
            Location location = Instantiate(locationData.Location);
            RenderSettings.skybox = locationData.SkyboxMaterial;
            _barrier.gameObject.SetActive(false);
            _surface.BuildNavMesh();
            _barrier.gameObject.SetActive(true);
            EnemyData enemyData = GetElement(levelIndex, _enemies);
            _waveFactory = new WaveFactory(location, enemyData);
            IWave wave = _waveFactory.Build(levelIndex);
            Level level = new Level(location, wave);
            Built?.Invoke(level);
            return level;
        }

        private T GetElement<T>(float levelIndex, T[] elements, bool isPositiveOffcet = true)
        {
            int index = GetIndexFromLevel(levelIndex, elements.Length, isPositiveOffcet);
            return elements[index];
        }

        private int GetIndexFromLevel(float levelIndex, int maxIndex, bool isPositiveOffcet = true)
        {
            int combinationsValue = _levelBatchValue * maxIndex;
            int index = Mathf.FloorToInt((levelIndex - 1) % combinationsValue / _levelBatchValue);
            int offsetValue = Mathf.FloorToInt((levelIndex - 1) / combinationsValue);

            if (levelIndex > combinationsValue)
            {
                index = (index + offsetValue) % maxIndex;

                if (isPositiveOffcet)
                    return index;
                else
                    index = maxIndex - index - 1;
            }

            return index;
        }
    }
}