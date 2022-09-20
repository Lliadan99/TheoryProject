using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 25.0f;
    public float damage = 5f;

    void Update()
    {
        transform.Translate(new Vector3(1f, 0f, 0f) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyRanged") || other.gameObject.CompareTag("EnemyTank") || other.gameObject.CompareTag("EnemyMelee"))
        {
            other.gameObject.GetComponent<Enemy>().AdjustHealth(5f);
            gameObject.SetActive(false);
        }
    }
}
