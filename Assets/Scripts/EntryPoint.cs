using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _locationPrefab;
    [SerializeField] private InputManager _inputManager;

    private LocationSpawner _locationSpawner;

    private void Awake()
    {
        if (_locationPrefab == null)
        {
            Debug.LogError("locationPrefab не назначен!");
            return;
        }

        _locationSpawner = new LocationSpawner(_locationPrefab);
        _locationSpawner.SpawnLocation();
    }

    private void Start()
    {
        if (_inputManager == null)
        {
            Debug.LogError("Не назначен InputManager!");
            return;
        }

        _inputManager.EnableInput();
    }

    private void OnDisable()
    {
        _inputManager?.DisableInput();
    }
}