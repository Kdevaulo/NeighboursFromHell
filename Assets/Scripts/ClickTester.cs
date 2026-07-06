using UnityEngine;

public class ClickTester : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private void OnEnable()
    {
        // подписка, когда объект активен
        inputManager.OnLeftClick += HandleLeftClick;
        inputManager.OnRightClick += HandleRightClick;
    }

    private void OnDisable()
    {
        // отписка, когда объект выключается
        inputManager.OnLeftClick -= HandleLeftClick;
        inputManager.OnRightClick -= HandleRightClick;
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