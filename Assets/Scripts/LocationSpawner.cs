using UnityEngine;

public class LocationSpawner
{
    private GameObject _locationPrefab;
    private GameObject _location;
    private Vector3 _spawnPoint = Vector3.zero;

    public LocationSpawner(GameObject locationPrefab)
    {
        _locationPrefab = locationPrefab;
    }

    public void SpawnLocation()
    {
        if (_locationPrefab == null)
        {
            Debug.Log("Префаб локации не назначен!");
            return;
        }

        _location = Object.Instantiate(_locationPrefab, _spawnPoint, Quaternion.identity);
    }

    public void DestroyLocation()
    {
        if (_location != null)
        {
            Object.Destroy(_location);
        }
    }
}