using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{    
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    protected Camera _camera;
    private System.Random _random;
    private List<GameObject> _pool;

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
            item.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    protected void Initialize<T>(T[] prefabs) where T : MonoBehaviour
    {
        _pool = new List<GameObject>();
        _camera = Camera.main;
        _random = new System.Random();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = GetRandomPrefab(prefabs);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialize<T>(T prefab) where T : MonoBehaviour
    {
        Initialize(new T[] { prefab });
    }
        
    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);
        return result != null;
    }
        
    private GameObject GetRandomPrefab<T>(T[] prefabs) where T : MonoBehaviour
    {
        int containerIndex = _random.Next(prefabs.Length);
        GameObject gameObject = Instantiate(prefabs[containerIndex].gameObject, _container);
        return gameObject;
    }
}
