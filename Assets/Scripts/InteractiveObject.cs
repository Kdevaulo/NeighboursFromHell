using System;

using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private InteractiveData[] _interactiveData;
    [SerializeField] private Transform _transform;

    private ObjectSpawner _objectSpawner;

    private void Awake()
    {
        _objectSpawner = new ObjectSpawner(_interactiveData, _transform);
    }

    private void OnEnable()
    {
        _objectSpawner.SpawnObjects();
    }

    private void OnDisable()
    {
        _objectSpawner?.DestroyObjects();
    }
}