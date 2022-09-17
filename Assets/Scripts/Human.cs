using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{

    private float _health = 25.0f;
    private float _movementSpeed = 8.0f;
    private float _speedModifier = 0.5f;
    private float _rotationSpeed = 800.0f;
    private float _attackDamage = 5.0f;
    private bool _isAlive = true;


    public Human()
    {
    }

    public float Health
    {
        get { return _health; }
    }

    public float MovementSpeed
    {
        get { return _movementSpeed; }
    }

    public float SpeedModifier
    {
        get { return _speedModifier; }
        set 
        {
            if(value>0 && value < 2)
            {
                _speedModifier = value;
            }
        }
    }

    public float RotationSpeed
    {
        get { return _rotationSpeed; }
        private set { }
    }
    
    public float AttackDamage
    {
        get {return _attackDamage; }
        set
        {
            if(value > 0 && value < 25)
            {
                _attackDamage = value;
            }
        }
    }

    public bool IsAlive
    {
        get {return _isAlive; }
        set { _isAlive = value; }
    }

    protected void AdjustHealth(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            _isAlive = false;
        }
    }

    protected virtual void Move()
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Die()
    {

    }

    protected virtual void Start()
    {
        
    }

    protected void Update()
    {
        if (!_isAlive)
        {
            Die();
        }

    }
}
