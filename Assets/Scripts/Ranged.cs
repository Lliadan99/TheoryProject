using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Ranged : Enemy
{
    public FireWeaponDetails fireWeaponDetails;
    private float _rangedRateOfFire = 2f;

    // POLYMORPHISM
    protected override void Awake()
    {
        base.Awake();
        MovementSpeed = MovementSpeed * 0.3f;
        fireWeaponDetails.canFire = true;
        PointValue = PointValue * 3;
    }

    private void OnEnable()
    {
        ReEnable();
    }

    // POLYMORPHISM
    protected override void Update()
    {
        base.Update();
        if (!GameManager.SharedInstance.gameOver)
        {
            fireWeaponDetails.AimWeapon(Target);
            FireWeapon();
        }
    }

    // POLYMORPHISM
    protected override void ReEnable()
    {
        base.ReEnable();
        fireWeaponDetails.canFire = true;
        
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
