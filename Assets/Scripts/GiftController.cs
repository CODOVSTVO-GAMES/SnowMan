using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftController : MonoBehaviour
{
    private bool ScaleB;
    private bool ScaleMove;
    private float a;
    private float b;
    private Vector3 ScaleSave;
    public void DeltaScale()
    {
        ScaleB = true;
        ScaleMove = true;
        ScaleSave = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void FixedUpdate()
    {
        if (ScaleB)
        {
            if (ScaleMove)
            {
                a += Time.deltaTime * 5f;
                float ScaleDeltaX = Mathf.Lerp(ScaleSave.x, ScaleSave.x * 1.3f, a);
                float ScaleDeltaY = Mathf.Lerp(ScaleSave.y, ScaleSave.y * 1.3f, a);
                float ScaleDeltaZ = Mathf.Lerp(ScaleSave.z, ScaleSave.z * 1.3f, a);
                transform.localScale = new Vector3(ScaleDeltaX, ScaleDeltaY, ScaleDeltaZ);
                if (a >= 1)
                {
                    ScaleMove = false;
                }
            }
            if (!ScaleMove)
            {
                b += Time.deltaTime * 5f;
                float ScaleDeltaX = Mathf.Lerp(ScaleSave.x * 1.3f, ScaleSave.x, b);
                float ScaleDeltaY = Mathf.Lerp(ScaleSave.y * 1.3f, ScaleSave.y, b);
                float ScaleDeltaZ = Mathf.Lerp(ScaleSave.z * 1.3f, ScaleSave.z, b);
                transform.localScale = new Vector3(ScaleDeltaX, ScaleDeltaY, ScaleDeltaZ);
                if (b >= 1)
                {
                    ScaleB = false;
                }
            }
        }
    }
}