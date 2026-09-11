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
        foreach (var t in _items)
        {
            if (t.objectPrefab == null)
            {
                Debug.LogError($"ObjectPrefab {t.nameObject} не назначены!");
                return;
            }

            GameObject spawned = Object.Instantiate(t.objectPrefab, t.positionObject, Quaternion.identity, _transformParent);
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