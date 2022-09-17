using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    private void Awake()
    {
        SpeedModifier = 0.2f;
    }
}
