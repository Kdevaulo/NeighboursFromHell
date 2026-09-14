using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfig", menuName = "LevelConfig", order = 51)]
public class LevelConfig : ScriptableObject
{
    public InteractiveData[] _items;
}