using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyBullet : Bullet
{
    // POLYMORPHISM
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().AdjustHealth(Damage);
            gameObject.SetActive(false);
        }
    }
}
