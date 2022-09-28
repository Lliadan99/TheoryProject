using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    private void Awake()
    {
        MaxHealth *= 4;
        MovementSpeed = MovementSpeed * 0.5f;
    }

    private void OnEnable()
    {
        ReEnable();
    }
}
