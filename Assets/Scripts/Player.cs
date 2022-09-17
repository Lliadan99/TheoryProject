using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Human
{
    public InputManager _inputManager;
    public PlayerAim playerAim;

    public Rigidbody rb;

    private void Awake()
    {
    }

    protected override void Move()
    {
        transform.position = transform.position + new Vector3(_inputManager.InputVector.x * MovementSpeed * Time.deltaTime, 0, _inputManager.InputVector.y * MovementSpeed * Time.deltaTime);
        //rb.MovePosition(rb.position + _inputManager.InputVector * MovementSpeed * Time.deltaTime);

    }

    protected override void Attack()
    {
        if (_inputManager.Attack)
        {
            if (!playerAim._canFire)
            {
                return;
            }
            playerAim.Fire();
        }
    }

    private new void Update()
    {

        Move();
        Attack();
    }
}
