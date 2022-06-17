using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 1.0f, 0f);
    }
}
