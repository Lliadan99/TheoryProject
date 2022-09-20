using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float horizontalBound = 27f;
    float verticalBound = 16f;

    void Update()
    {
        if (transform.position.z > verticalBound || transform.position.z < -verticalBound || transform.position.x > horizontalBound || transform.position.x < -horizontalBound)
        {
            gameObject.SetActive(false);
        }
    }
}
