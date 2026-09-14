using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField] private InteractiveData _data;
    [SerializeField] private SpriteRenderer _renderer;

    private void Awake()
    {
        if (!ValidationHelper.CheckRefs(this, _data, _renderer))
        {
            enabled = false;
        }
    }

    public void Break()
    {
        if (_data.stateObject == StateObject.Operational)
        {
            _renderer.sprite = _data.imageObjectBroken;
            _data.stateObject = StateObject.Broken;
        }
    }

    public void Repair()
    {
        if (_data.stateObject == StateObject.Broken)
        {
            _renderer.sprite = _data.imageObjectBase;
            _data.stateObject = StateObject.Operational;
        }
    }
}

public enum StateObject
{
    Operational,
    Broken
}