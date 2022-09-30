using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Human
{
    public InputManager inputManager;
    public FireWeaponDetails fireWeaponDetails;
    public Camera mainCamera;

    private Vector3 _mousePosition;
    private Plane _plane;
    private Ray _ray;
    private float _direction;
    private float _playerRateOfFire = 0.2f;

    public bool lastHeart = false;

    private void Awake()
    {
        MaxHealth *= 3;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }

    private void Update()
    {
        if (IsAlive)
        {
            Move();
            fireWeaponDetails.AimWeapon(TargetMouse());
            FireWeapon();
            GameManager.SharedInstance.HeartDisplay(CurrentHealth);
        }
        else
        {
            if (!lastHeart)
            {
                GameManager.SharedInstance.HeartDisplay(CurrentHealth);
                lastHeart = true;
            }
            GameManager.SharedInstance.gameOver = true;
        }
    }

    protected override void Move()
    {
        transform.position = transform.position + new Vector3(inputManager.InputVector.x * MovementSpeed * Time.deltaTime, 0, inputManager.InputVector.y * MovementSpeed * Time.deltaTime);
    }
    private Vector3 TargetMouse()
    {
        _plane = new Plane(transform.up, 0);
        _ray = mainCamera.ScreenPointToRay(inputManager.MousePos);
        if (_plane.Raycast(_ray, out _direction))
        {
            _mousePosition = _ray.GetPoint(_direction);
            return _mousePosition;
        }
        throw new UnityException("Mouse not intersecting");
    }

    private void FireWeapon()
    {
        if (inputManager.Attack)
        {
            if (!fireWeaponDetails.canFire)
            { 
                return;
            }
            fireWeaponDetails.Fire("PlayerBullet", _playerRateOfFire);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyRanged") || other.gameObject.CompareTag("EnemyTank") || other.gameObject.CompareTag("EnemyMelee"))
        {
            AdjustHealth(HitDamage);
            other.gameObject.SetActive(false);
        }
    }
}
