using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{    
    [SerializeField] private int _capacity;

    protected Camera _camera;
    private List<GameObject> _pool;

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
            item.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    protected void Initialize<T>(T prefab, float parameter) where T : MonoBehaviour
    {
        _pool = new List<GameObject>();
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = GetObjectWithParameter(prefab, parameter);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }

    }

    protected abstract GameObject GetObjectWithParameter<T>(T prefab, float parameter) where T : MonoBehaviour;
        
    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);
        return result != null;
    }    
}
