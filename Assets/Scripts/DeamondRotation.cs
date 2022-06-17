using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeamondRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 1.0f);
    }
}
