using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _locationPrefab;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private InteractiveObject _interactive;
    
    private LocationSpawner _locationSpawner;

    private void Awake()
    {
        _locationSpawner = new LocationSpawner(_locationPrefab);
        _locationSpawner.SpawnLocation();
    }

    private void Start()
    {
        if (_inputManager == null || _interactive == null)
        {
            Debug.LogErrorFormat("Не назначен InputManager или Interactive!");
            return;
        }
        _inputManager.EnableInput();
    }

    private void OnDisable()
    {
        _inputManager?.DisableInput();
    }
}