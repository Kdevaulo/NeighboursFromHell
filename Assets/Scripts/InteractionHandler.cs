using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private InteractiveItemsManager _interactive;

    private void Awake()
    {
        if (!ValidationHelper.CheckRefs(this, _inputManager, _mainCamera, _interactive))
        {
            enabled = false;
        }
    }

    private void OnEnable()
    {
        _inputManager.OnLeftClick += HandleLeftClick;
        _inputManager.OnRightClick += HandleRightClick;
    }

    private void OnDisable()
    {
        _inputManager.OnLeftClick -= HandleLeftClick;
        _inputManager.OnRightClick -= HandleRightClick;
    }

    private void HandleLeftClick()
    {
        var collPoint = GetColliderUnderMouse();

        if (collPoint != null)
        {
            var item = collPoint.GetComponent<InteractiveItem>();
            item.Break();
        }
    }

    private void HandleRightClick()
    {
        var collPoint = GetColliderUnderMouse();

        if (collPoint != null)
        {
            var item = collPoint.GetComponent<InteractiveItem>();
            item.Repair();
        }
    }

    private Collider2D GetColliderUnderMouse()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = _mainCamera.ScreenToWorldPoint(screenPos);
        Collider2D collPoint = Physics2D.OverlapPoint(worldPos);
        return collPoint;
    }
}