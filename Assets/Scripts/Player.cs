using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Human
{
    public InputManager inputManager;
    public AttackDetails attackDetails;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }

    protected override void Move()
    {
        transform.position = transform.position + new Vector3(inputManager.InputVector.x * MovementSpeed * Time.deltaTime, 0, inputManager.InputVector.y * MovementSpeed * Time.deltaTime);
    }

    protected override void Attack()
    {
        if (inputManager.Attack)
        {
            if (!attackDetails._canFire)
            {
                return;
            }
            attackDetails.Fire();
        }
    }

    private void Update()
    {
        if (!IsAlive)
        {
            GameManager.SharedInstance.gameOver = true;
        }

        Move();
        Attack();
    }
    private void OnTriggerEnter(Collider other)
    {
        AdjustHealth(5f);
    }
}
