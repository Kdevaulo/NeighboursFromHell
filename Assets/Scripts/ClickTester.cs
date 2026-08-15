using UnityEngine;

public class ClickTester : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;

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
        Debug.Log("ЛКМ клик!");
    }

    private void HandleRightClick()
    {
        Debug.Log("ПКМ клик!");
    }
}