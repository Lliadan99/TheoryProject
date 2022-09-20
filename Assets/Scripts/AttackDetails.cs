using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetails : MonoBehaviour
{
    public InputManager inputManager;

    private Camera _mainCam;
    private Transform _muzzle;

    public GameObject bullet;

    //private Vector3 mousePos;
    private Vector3 _inPlanePos;
    private Vector3 _rotation;
    private Vector3 _weaponAngle;
    private float _angle;

    public bool _canFire = true;

    private void Awake()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _muzzle = GameObject.FindGameObjectWithTag("Muzzle").GetComponent<Transform>();
    }

    void Update()
    {
        Aim();
        WeaponAngle();
    }

    private void Aim()
    {
        //mousePos = Mouse.current.position.ReadValue();
        _inPlanePos = GetMousePositionInPlane();
        _rotation = _inPlanePos - transform.position;
        _angle = Mathf.Atan2(-_rotation.z, _rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, _angle, 0);
    }
    public Vector3 GetMousePositionInPlane()
    {
        Plane plane = new Plane(transform.up, 0);
        Ray ray = _mainCam.ScreenPointToRay(inputManager.MousePos);
        float direction;
        if (plane.Raycast(ray, out direction))
        {
            Vector3 vector = ray.GetPoint(direction);
            return vector;
        }
        throw new UnityException("mouse not intersecting");
    }

    private void WeaponAngle()
    {
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
    public void Fire()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet");
        {
            if (bullet != null)
            {
                bullet.transform.position = _muzzle.transform.position;
                bullet.transform.rotation = _muzzle.transform.rotation;
                bullet.SetActive(true);
            }
            StartCoroutine(CanFire());
        }
    }

    IEnumerator CanFire()
    {
        _canFire = false;
        yield return new WaitForSeconds(.2f);
        _canFire = true;
    }
}
