using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameInputActions _inputActions;
    private bool _isSubscribed = false;

    public event Action OnLeftClick = delegate { };
    public event Action OnRightClick;

    private void Awake()
    {
        _inputActions = new GameInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        TrySubscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
        _inputActions.Disable();
    }

    private void OnDestroy()
    {
        _inputActions.Dispose();
    }

    public void TrySubscribe()
    {
        if (!_isSubscribed)
        {
            _inputActions.Gameplay.LeftClick.performed += HandleLeftClick;
            _inputActions.Gameplay.RightClick.performed += HandleRightClick;
            _isSubscribed = true;
            Debug.Log("Подписка активна");
        }
    }

    public void Unsubscribe()
    {
        if (_isSubscribed)
        {
            _inputActions.Gameplay.LeftClick.performed -= HandleLeftClick;
            _inputActions.Gameplay.RightClick.performed -= HandleRightClick;
            _isSubscribed = false;
            Debug.Log("Подписка отключена");
        }
    }

    private void HandleLeftClick(InputAction.CallbackContext context)
    {
        OnLeftClick.Invoke();
    }

    private void HandleRightClick(InputAction.CallbackContext context)
    {
        OnRightClick?.Invoke();
    }
    
    public void EnableInput()
    {
        _inputActions.Enable();
        TrySubscribe();
    }

    public void DisableInput()
    {
        Unsubscribe();
        _inputActions.Disable();
    }
}