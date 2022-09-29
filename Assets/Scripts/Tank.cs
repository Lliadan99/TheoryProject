using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        MaxHealth *= 4;
        MovementSpeed = MovementSpeed * 0.5f;
        PointValue = PointValue * 2;
    }

    private void OnEnable()
    {
        ReEnable();
    }
}
