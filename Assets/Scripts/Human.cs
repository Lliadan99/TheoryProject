using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{

    private float _maxHealth = 5.0f;
    private float _currentHealth;
    private float _movementSpeed = 8.0f;
    private float _attackDamage = 5.0f;
    private bool _isAlive = true;

    public Human()
    {
    }

    public float MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            if(value > 0 && value <50)
            {
                _maxHealth = value;
            }
        }
    }
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if(_currentHealth <= _maxHealth)
            {
                if (_currentHealth < 0)
                {
                    _currentHealth = 0;
                }
                _currentHealth = value;
            }
        }
    }

    public float MovementSpeed
    {
        get { return _movementSpeed; }
        set
        {
            if(value > 0 && value < 25)
            {
                _movementSpeed = value;
            }
        }
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

    public void AdjustHealth(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
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
}
