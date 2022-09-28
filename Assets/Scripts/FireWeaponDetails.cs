using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeaponDetails : MonoBehaviour
{
    private Vector3 _rotation;
    private Vector3 _weaponAngle;
    private float _angle;

    public GameObject bullet;
    public Transform muzzle;

    public bool canFire = true;

    public void AimWeapon(Vector3 target)
    {
        _rotation = target - transform.position;
        _angle = Mathf.Atan2(-_rotation.z, _rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, _angle, 0);
        _weaponAngle = Vector3.one;
        if (_angle > 90 || _angle < -90)
        {
            _weaponAngle.z = -1f;
        }
        else
        {
            _weaponAngle.z = 1f;
        }
        transform.localScale = _weaponAngle;
    }

    public void Fire(string tag, float fireRate)
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(tag);
        {
            if (bullet != null)
            {
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.SetActive(true);
            }
            StartCoroutine(CanFire(fireRate));
        }
    }

    IEnumerator CanFire(float rate)
    {
        canFire = false;
        yield return new WaitForSeconds(rate);
        canFire = true;
    }
}
