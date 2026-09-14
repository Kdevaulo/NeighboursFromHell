using System.Collections.Generic;

using UnityEngine;

public class ObjectSpawner
{
    private LevelConfig _levelConfig;
    private Transform _transformParent;

    private List<GameObject> _spawnedObjects = new List<GameObject>();

    public ObjectSpawner(LevelConfig levelConfig, Transform transform)
    {
        _levelConfig = levelConfig;
        _transformParent = transform;
    }

    public void SpawnObjects()
    {
        foreach (var item in _levelConfig._items)
        {
            if (item.objectPrefab == null)
            {
                Debug.LogError($"ObjectPrefab {item.nameObject} не назначены!");
                return;
            }

            GameObject spawned = Object.Instantiate(item.objectPrefab, item.positionObject, Quaternion.identity, _transformParent);
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