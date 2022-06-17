using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScale : MonoBehaviour
{
    float a;
    bool DeltaScaleB;
    public void DeltaScale()
    {
        DeltaScaleB = true;
    }
    private void FixedUpdate()
    {
        if (DeltaScaleB)
        {
            a += Time.deltaTime * 5f;
            float Scale = Mathf.Lerp(2f, 0f, a);
            transform.localScale = new Vector3(Scale, Scale, Scale);
            if (a >= 1) DeltaScaleB = false;
        }
    }
}
