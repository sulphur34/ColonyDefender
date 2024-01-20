using UnityEngine;

public class Level
{
    private Location _location;

    public IWave Wave { get; private set; }

    public Level(Location terrain, IWave wave)
    {
        _location = terrain;
        Wave = wave;
    }
    
    public void Clear()
    {
        MonoBehaviour.Destroy(_location.gameObject);
        Wave.Clear();
    }
}
