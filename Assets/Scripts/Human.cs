using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{
    private int _maxHealth = 5;
    private int _currentHealth;
    private float _movementSpeed = 8.0f;
    private int _hitDamage = 5;
    private bool _isAlive = true;

    public Human()
    {
    }

    public int MaxHealth
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
    public int CurrentHealth
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

    public int HitDamage
    {
        get {return _hitDamage; }
        set
        {
            if(value > 0 && value < 25)
            {
                _hitDamage = value;
            }
        }
    }

    public bool IsAlive
    {
        get {return _isAlive; }
        set { _isAlive = value; }
    }

    public void AdjustHealth(int damage)
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
}
