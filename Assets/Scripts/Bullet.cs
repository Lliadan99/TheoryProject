using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 25.0f;
    private float _damage = 5f;

    public Bullet()
    {
    }

    public float Speed
    {
        get { return _speed; }
        set
        {
            if (value > 0)
            {
                _speed = value;
            }
        }
    }

    public float Damage
    {
        get { return _damage; }
        set
        {
            if (value > 0)
            {
                _damage = value;
            }
        }
    }

    void Update()
    {
        BulletMove();
    }

    protected virtual void BulletMove()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyRanged") || other.gameObject.CompareTag("EnemyTank") || other.gameObject.CompareTag("EnemyMelee"))
        {
            other.gameObject.GetComponent<Enemy>().AdjustHealth(_damage);
            gameObject.SetActive(false);
        }
    }

}
