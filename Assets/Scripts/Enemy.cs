using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Enemy : Human
{
    private Vector3 _target;
    private int _pointValue = 20;
    private Vector3 _direction;
    private GameObject _player;

    // ENCAPSULATION
    public Vector3 Target
    {
        get { return _target; }
    }
    public int PointValue
    {
        get { return _pointValue; }
        set
        {
            if (value > 0)
            {
                _pointValue = value;
            }
        }
    }

    protected virtual void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        MovementSpeed = 6f;
    }

    protected virtual void Update()
    {
        if (!IsAlive)
        {
            GameManager.SharedInstance.UpdateScore(_pointValue);
            gameObject.SetActive(false);
        }
        if (!GameManager.SharedInstance.gameOver)
        {
            Move();
        }
    }

    protected virtual void ReEnable()
    {
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }

    // POLYMORPHISM
    protected override void Move()
    {
        _target = _player.transform.position;
        _direction = _target - transform.position;
        if (_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
        }
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
    }
}
