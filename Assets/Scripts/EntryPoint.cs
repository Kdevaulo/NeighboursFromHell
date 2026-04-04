using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _locationPrefab;
    
    private LocationSpawner _locationSpawner;
    
    void Awake()
    {
        _locationSpawner = new LocationSpawner(_locationPrefab);
        _locationSpawner.SpawnLocation();
    }
}
