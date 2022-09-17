using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput _playerInput = null;

    private Vector3 _inputVector;
    private bool _attack = false;
      
    public Vector3 InputVector
    {
        get { return _inputVector; }
    }

    public bool Attack
    {
        get { return _attack; }
    }


    private void OnEnable()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();

        _playerInput.Player.Move.performed += SetMovementVector;
        _playerInput.Player.Move.canceled += SetMovementVector;

        _playerInput.Player.Shoot.performed += SetShoot;
        _playerInput.Player.Shoot.canceled += SetShoot;
    }

    private void OnDisable()
    {
        _playerInput.Player.Move.performed -= SetMovementVector;
        _playerInput.Player.Move.canceled -= SetMovementVector;

        _playerInput.Player.Shoot.performed -= SetShoot;
        _playerInput.Player.Shoot.canceled -= SetShoot;

        _playerInput.Player.Disable();
    }

    public void SetMovementVector(InputAction.CallbackContext ctx)
    {
        _inputVector = ctx.ReadValue<Vector2>();
        _inputVector.z = 0f;
    }

    public void SetShoot(InputAction.CallbackContext ctx)
    {
        _attack = ctx.ReadValueAsButton();
        
    }
    private void Start()
    {

    }

    private void Update()
    {

    }
}
