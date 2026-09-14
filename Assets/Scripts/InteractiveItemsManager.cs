using UnityEngine;

public class InteractiveItemsManager : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Transform _transform;

    private ObjectSpawner _objectSpawner;

    private void Awake()
    {
        if (!ValidationHelper.CheckRefs(this, _levelConfig, _transform))
        {
            enabled = false;
        }
        _objectSpawner = new ObjectSpawner(_levelConfig, _transform);
    }

    public void SpawnInteractiveObjects()
    {
        _objectSpawner?.SpawnObjects();
    }

    public void DestroyInteractiveObjects()
    {
        _objectSpawner?.DestroyObjects();
    }
}