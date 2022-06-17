using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public GameObject PlayerHead;
    private Camera _camera;
    private float posZ = 10f;
    private bool ZoomPlusB;
    private float ZoomPlusF = 0.3f;
    private bool ZoomMinusB;
    private float ZoomMinusF = 0.3f;
    private bool FinishTransformCameraB;
    private bool CameraOnTheSide;
    private float time;
    private int Count;
    void Start()
    {
        _camera = Camera.main;
    }
    void LateUpdate()
    {
        if (!FinishTransformCameraB)
        {
            if (PlayerHead != null)
            {
                if (SceneManager.GetActiveScene().buildIndex % 5 != 0) Count = gameObject.GetComponent<GameManager>().Player.GetComponent<PlayersController>().TorCount;
                Vector3 pos = PlayerHead.transform.position;
                pos.z = pos.z - posZ;
                pos.x = pos.x + 2;
                if (SceneManager.GetActiveScene().buildIndex % 5 != 0) pos.y = pos.y + 4 - 0.65f - Count * 0.07f;
                else pos.y = pos.y + 4 - 0.65f;
                transform.position = pos;
            }
        }
        else if (CameraOnTheSide)
        {
            Vector3 pos = PlayerHead.transform.position;
            // pos.z = pos.z;
            pos.x = posZ + Count * 0.2f;
            pos.y = pos.y - Count * 0.07f;
            transform.position = pos;
        }
    }
    public void ZoomPlus()
    {
        ZoomPlusB = true;
    }
    public void ZoomMinus()
    {
        ZoomMinusB = true;
    }
    private void FixedUpdate()
    {
        if (ZoomPlusB)
        {
            if (ZoomPlusF > 0)
            {
                posZ -= Time.fixedDeltaTime;
                ZoomPlusF -= Time.fixedDeltaTime;
            }
            else
            {
                ZoomPlusB = false;
                ZoomPlusF = 0.5f;
            }
        }
        if (ZoomMinusB)
        {
            if (ZoomMinusF > 0)
            {
                posZ += Time.fixedDeltaTime;
                ZoomMinusF -= Time.fixedDeltaTime;
            }
            else
            {
                ZoomMinusB = false;
                ZoomMinusF = 0.5f;
            }
        }
        if (FinishTransformCameraB)
        {
            RenderSettings.fog = false;
            if (!CameraOnTheSide)
            {
                if (time < 1)
                {
                    time += Time.fixedDeltaTime * 2f;
                    float x = Mathf.Lerp(2f, posZ + Count * 0.5f, time);
                    transform.position = new Vector3(x, PlayerHead.transform.position.y, PlayerHead.transform.position.z);
                    float rotX = Mathf.Lerp(transform.rotation.x, 0f, time);
                    float rotY = Mathf.Lerp(transform.rotation.y, -90f, time);
                    transform.rotation = Quaternion.Euler(rotX, rotY, 0f);
                }
                else
                {
                    CameraOnTheSide = true;
                }
            }
        }
    }
    public void FinishTransformCamera(int count)
    {
        FinishTransformCameraB = true;
        Count = count;
    }
    public void Multiplier()
    {
        Count = (int)(Count * 1.2f);
    }
}