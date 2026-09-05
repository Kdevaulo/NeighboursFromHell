using UnityEngine;

[CreateAssetMenu(fileName = "New InteractiveData", menuName = "InteractiveData", order = 51)]
public class InteractiveData : ScriptableObject
{
    [Header("Visuals")]
    public string nameObject;
    public Sprite imageObjectBase;
    public Sprite imageObjectBroken;
    
    [Header("Settings")]
    public GameObject objectPrefab;
    public Vector3 positionObject;
}