using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    private static InputManager inputInstance;
    public static InputManager Instance { get { return inputInstance; } }

    //Variables
    InputMaps _inputMap;


    //Propeties
    

    private void Awake()
    {
        InitializeInstance();
        InitializeInputMap();
    }

    private void OnEnable() => _inputMap.Enable();
    private void OnDisable() => _inputMap.Disable();

    private void InitializeInstance()
    {
        if (inputInstance != null && inputInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        inputInstance = this;
    }

    private void InitializeInputMap()
    {
        _inputMap = new InputMaps();
        _inputMap.Player.TouchButton.performed += ctx => HandleTouch(ctx);
        _inputMap.Player.MouseButton.performed += ctx => HandleTouch(ctx);
    }

    private void HandleTouch(InputAction.CallbackContext ctx)
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputMap.Player.MousePosition.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
