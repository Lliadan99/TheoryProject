using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Human
{
    private Vector3 _target;
    private Vector3 _direction;

    private void Awake()
    {
        MovementSpeed = 6f;
    }

    protected override void Move()
    {
        _target = GameObject.FindWithTag("Player").transform.position;
        _direction = _target - transform.position;

        if(_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
        }
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
    }

    protected virtual void ReEnable()
    {
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }
    private void Update()
    {
        if (!IsAlive)
        {
            gameObject.SetActive(false);
        }
        Move();
    }
}
