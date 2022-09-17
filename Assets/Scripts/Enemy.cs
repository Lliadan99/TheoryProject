using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Human
{
    private Vector3 _target;
    private Vector3 _direction;
    private float _step;


    protected override void Move()
    {
        _target = GameObject.FindWithTag("Player").transform.position;
        _step = MovementSpeed * SpeedModifier * Time.deltaTime;
        _direction = _target - transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, _target, step);

        if(_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
        }
        transform.position += transform.forward * _step;
    }

    private new void Update()
    {
        //Move();
    }
}
