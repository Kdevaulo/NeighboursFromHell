using System.Collections.Generic;

using UnityEngine;

public class ObjectSpawner
{
    private InteractiveData[] _items;
    private Transform _transformParent;

    private List<GameObject> _spawnedObjects = new List<GameObject>();

    public ObjectSpawner(InteractiveData[] items, Transform transform)
    {
        _items = items;
        _transformParent = transform;
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i].objectPrefab == null)
            {
                Debug.LogErrorFormat("ObjectPrefab {0} не назначены!", _items[i].nameObject);
                return;
            }

            GameObject spawned = Object.Instantiate(_items[i].objectPrefab, _items[i].positionObject, Quaternion.identity, _transformParent);
            _spawnedObjects.Add(spawned);
        }
    }

    public void DestroyObjects()
    {
        foreach (var spawned in _spawnedObjects)
        {
            if (spawned != null)
            {
                Object.Destroy(spawned);
            }
        }
        _spawnedObjects.Clear();
    }
}