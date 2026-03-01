using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _locationPrefab;

    private GameObject _location;
    
    void Awake()
    {
        if (_locationPrefab == null)
        {
            return;
        }
        
        _location = Instantiate(_locationPrefab, transform);
    }
}
