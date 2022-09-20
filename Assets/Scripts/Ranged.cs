using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Enemy
{
    private void Awake()
    {
        MovementSpeed = MovementSpeed * 0.75f;
    }

    private void OnEnable()
    {
        ReEnable();
    }
}
