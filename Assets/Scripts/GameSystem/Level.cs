using Terrain;
using UnityEngine;
using Utils.Interfaces;

namespace GameSystem
{
    public class Level
    {
        private Location _location;

        public Level(Location terrain, IWave wave)
        {
            _location = terrain;
            Wave = wave;
        }

        public IWave Wave { get; private set; }

        public void Clear()
        {
            MonoBehaviour.Destroy(_location.gameObject);
            Wave.Clear();
        }
    }
}
