using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action OnLeftClick = delegate { };
    public event Action OnRightClick;

    private GameInputActions _inputActions;
    private InputAction _leftClick;
    private InputAction _rightClick;
    private bool _isSubscribed = false;

    private void Awake()
    {
        _inputActions = new GameInputActions();
        _leftClick = _inputActions.Gameplay.LeftClick;
        _rightClick = _inputActions.Gameplay.RightClick;
    }

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void OnDestroy()
    {
        _inputActions.Dispose();
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

    private void TrySubscribe()
    {
        if (!_isSubscribed)
        {
            _leftClick.performed += HandleLeftClick;
            _rightClick.performed += HandleRightClick;
            _isSubscribed = true;
            Debug.Log("Подписка активна");
        }
    }

    private void Unsubscribe()
    {
        if (_isSubscribed)
        {
            _leftClick.performed -= HandleLeftClick;
            _rightClick.performed -= HandleRightClick;
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
}