using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAim : MonoBehaviour
{
    private Camera mainCam;
    private Transform muzzle;

    public GameObject bullet;

    private Vector3 mousePos;
    private Vector3 inPlanePos;
    private Vector3 rotation;
    private Vector3 weaponAngle;
    private float angle;

    public bool _canFire = true;

    private void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        muzzle = GameObject.FindGameObjectWithTag("Muzzle").GetComponent<Transform>();
    }

    void Update()
    {
        Aim();
        WeaponAngle();
    }

    private void Aim()
    {
        mousePos = Mouse.current.position.ReadValue();
        inPlanePos = GetMousePositionInPlane();
        rotation = inPlanePos - transform.position;
        angle = Mathf.Atan2(-rotation.z, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    public Vector3 GetMousePositionInPlane()
    {
        Plane plane = new Plane(transform.up, 0);
        Ray ray = mainCam.ScreenPointToRay(mousePos);
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
        weaponAngle = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            weaponAngle.z = -1f;
        }
        else
        {
            weaponAngle.z = 1f;
        }
        transform.localScale = weaponAngle;
    }
    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        //newProjectile.SetActive(true);
        StartCoroutine(CanFire());
    }

    IEnumerator CanFire()
    {
        _canFire = false;
        yield return new WaitForSeconds(.2f);
        _canFire = true;
    }

}
