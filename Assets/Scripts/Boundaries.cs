using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private float _xRange = 23.5f;
    private float _zRange = 13f;

    void Update()
    {
        OutOfBounds();
    }
    private void OutOfBounds()
    {
        if (transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -_zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -_zRange);
        }
        if (transform.position.z > _zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _zRange);
        }
    }
}
