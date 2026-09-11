using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Camera _mainCamera;

    private void Awake()
    {
        if (!ValidationHelper.CheckRefs(this, _inputManager, _mainCamera))
        {
            enabled = false;
        }
    }

    private void OnEnable()
    {
        // подписка, когда объект активен
        _inputManager.OnLeftClick += HandleLeftClick;
        _inputManager.OnRightClick += HandleRightClick;
    }

    private void OnDisable()
    {
        // отписка, когда объект выключается
        _inputManager.OnLeftClick -= HandleLeftClick;
        _inputManager.OnRightClick -= HandleRightClick;
    }

    private void HandleLeftClick()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = _mainCamera.ScreenToWorldPoint(screenPos);

        Collider2D collPoint = Physics2D.OverlapPoint(worldPos);

        if (collPoint != null)
        {
            Debug.Log("ЛКМ клик!");
            Debug.LogFormat("В коллайдер {0} попал", collPoint.name);
        }
    }

    private void HandleRightClick()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = _mainCamera.ScreenToWorldPoint(screenPos);

        Collider2D collPoint = Physics2D.OverlapPoint(worldPos);

        if (collPoint != null)
        {
            Debug.Log("ПКМ клик!");
            Debug.LogFormat("В коллайдер {0} попал", collPoint.name);
        }
    }
}