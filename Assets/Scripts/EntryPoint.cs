using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _locationPrefab;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private InteractiveObject _interactive;

    private LocationSpawner _locationSpawner;

    private void Awake()
    {
        if (!ValidationHelper.CheckRefs(this, _locationPrefab, _inputManager, _interactive))
        {
            enabled = false;
            return;
        }

        _locationSpawner = new LocationSpawner(_locationPrefab);
        _locationSpawner.SpawnLocation();
    }

    private void Start()
    {
        if (!ValidationHelper.CheckRefs(this, _locationPrefab, _inputManager, _interactive))
        {
            enabled = false;
            return;
        }

        _interactive.SpawnInteractiveObjects();
        _inputManager.EnableInput();
    }

    private void OnDisable()
    {
        _inputManager?.DisableInput();
    }
}