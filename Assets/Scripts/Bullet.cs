using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10.0f;

    //IEnumerable DestroyBulletAfterTime()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Destroy(gameObject);
    //}

    void Update()
    {
        transform.Translate(new Vector3 (1f, 0f, 0f) * speed * Time.deltaTime);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //}
}
