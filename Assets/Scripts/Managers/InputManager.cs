using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public Vector2 MousePos { get; private set; }
    public Vector2 WASDVector2 { get; set; }
    public Vector2 ArrowsVector2 { get; set; }

    private MainInput _mainInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _mainInput = new MainInput();
        }
    }

    private void Start()
    {
        _mainInput.FindAction("MouseMovement").performed += GetMousePos;
        _mainInput.FindAction("MouseMovement").canceled += GetMousePos;
        _mainInput.FindAction("KeyboardVector2").started += GetKeyboardVector2;
        _mainInput.FindAction("KeyboardVector2").canceled += GetKeyboardVector2;
        _mainInput.FindAction("MouseClick").started += MouseClicked;
        _mainInput.FindAction("Hide").performed += GetHideInput;
        _mainInput.FindAction("Arrows").performed += GetArrowsInput;
    }

    private void GetArrowsInput(InputAction.CallbackContext context)
    {
        ArrowsVector2 = context.ReadValue<Vector2>();
    }

    private void MouseClicked(InputAction.CallbackContext context)
    {
        print("mouse clicked");
    }

    private void GetMousePos(InputAction.CallbackContext context)
    {
        //MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        MousePos = context.ReadValue<Vector2>();
    }

    private void GetKeyboardVector2(InputAction.CallbackContext context)
    {
        WASDVector2 = context.ReadValue<Vector2>();
    }

    private void GetHideInput(InputAction.CallbackContext context)
    {
        EventManager.Instance.HideInputPressed();
    }

    private void OnEnable()
    {
        _mainInput.Enable();
    }
    private void OnDisable()
    {
        _mainInput.FindAction("MouseMovement").performed -= GetMousePos;
        _mainInput.FindAction("MouseMovement").canceled -= GetMousePos;
        _mainInput.FindAction("KeyboardVector2").started -= GetKeyboardVector2;
        _mainInput.FindAction("KeyboardVector2").canceled -= GetKeyboardVector2;
        _mainInput.FindAction("MouseClick").started -= MouseClicked;
        _mainInput.FindAction("Hide").performed -= GetHideInput;
        _mainInput.FindAction("Arrows").performed -= GetArrowsInput;
        _mainInput.Disable();
    }
}
