using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ranged : Enemy
{
    public FireWeaponDetails fireWeaponDetails;
    private GameObject _player;
    private float _rangedRateOfFire = 2f;


    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        MovementSpeed = MovementSpeed * 0.3f;
        fireWeaponDetails.canFire = true;
    }

    private void OnEnable()
    {
        ReEnable();
    }
    protected override void Update()
    {
        base.Update();
        fireWeaponDetails.AimWeapon(TargetPosition());
        FireWeapon();
    }

    protected override void ReEnable()
    {
        base.ReEnable();
        fireWeaponDetails.canFire = true;
        
    }
    private Vector3 TargetPosition()
    {
         return _player.transform.position;
    }

    private void FireWeapon()
    {
        if (!fireWeaponDetails.canFire)
        {
            return;
        }
        fireWeaponDetails.Fire("EnemyBullet", _rangedRateOfFire);
    }
}
