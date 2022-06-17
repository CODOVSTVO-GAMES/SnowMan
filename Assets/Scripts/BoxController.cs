using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    private bool TriggerOpen;
    private bool UpOpen;
    private bool UpOpenScale;
    private bool UpDeltaScalePresent;
    private bool PlusScale;
    private bool MinusScale;
    private float Speed = 20f;
    private float DeltaScale;
    private float TlS;
    private Vector3 movement = Vector3.up;
    private int Number;
    private int NumberTest;
    private CanvasGO canvasGO;
    public FinishMultiplier finishMultiplier;
    void Start()
    {
#if UNITY_EDITOR
        PlayerPrefs.SetInt("Num_0", 0);
        PlayerPrefs.SetInt("Num_1", 0);
        PlayerPrefs.SetInt("Num_2", 0);
        PlayerPrefs.SetInt("Num_3", 0);
        PlayerPrefs.SetInt("Num_4", 0);
        PlayerPrefs.SetInt("Num_5", 0);
        PlayerPrefs.SetInt("Num_6", 0);
        PlayerPrefs.SetInt("Num_7", 0);
        PlayerPrefs.SetInt("Num_8", 0);
        PlayerPrefs.SetInt("Num_9", 0);
        PlayerPrefs.SetInt("Num_10", 0);
        PlayerPrefs.SetInt("Num_11", 0);
#endif
        Number = Int32.Parse(gameObject.name.Substring(8));
        if (Number == 0) NumberTest = PlayerPrefs.GetInt("Num_0");
        if (Number == 1) NumberTest = PlayerPrefs.GetInt("Num_1");
        if (Number == 2) NumberTest = PlayerPrefs.GetInt("Num_2");
        if (Number == 3) NumberTest = PlayerPrefs.GetInt("Num_3");
        if (Number == 4) NumberTest = PlayerPrefs.GetInt("Num_4");
        if (Number == 5) NumberTest = PlayerPrefs.GetInt("Num_5");
        if (Number == 6) NumberTest = PlayerPrefs.GetInt("Num_6");
        if (Number == 7) NumberTest = PlayerPrefs.GetInt("Num_7");
        if (Number == 8) NumberTest = PlayerPrefs.GetInt("Num_8");
        if (Number == 9) NumberTest = PlayerPrefs.GetInt("Num_9");
        if (Number == 10) NumberTest = PlayerPrefs.GetInt("Num_10");
        if (Number == 11) NumberTest = PlayerPrefs.GetInt("Num_11");
        if (NumberTest == 1)
        {
            Destroy(gameObject);
            Destroy(finishMultiplier.Colliders[Number]);
        }
    }
    public void Open()
    {
        UpOpen = true;
        Number = Int32.Parse(gameObject.name.Substring(8));
        canvasGO = Camera.main.GetComponent<GameManager>().GamePanel.transform.parent.gameObject.GetComponent<CanvasGO>();
        if (Number == 0)
        {
            PlayerPrefs.SetInt("Num_0", 1);
            canvasGO.WinImageSkin[0].SetActive(true);
        }
        if (Number == 1)
        {
            PlayerPrefs.SetInt("Num_1", 1);
            canvasGO.WinImageSkin[0].SetActive(false);
            canvasGO.WinImageSkin[1].SetActive(true);
        }
        if (Number == 2)
        {
            PlayerPrefs.SetInt("Num_2", 1);
            canvasGO.WinImageSkin[0].SetActive(false);
            canvasGO.WinImageSkin[1].SetActive(false);
            canvasGO.WinImageSkin[2].SetActive(true);
        }
        if (Number == 3)
        {
            PlayerPrefs.SetInt("Num_3", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[3].SetActive(true);
        }
        if (Number == 4)
        {
            PlayerPrefs.SetInt("Num_4", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[4].SetActive(true);
        }
        if (Number == 5)
        {
            PlayerPrefs.SetInt("Num_5", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[5].SetActive(true);
        }
        if (Number == 6)
        {
            PlayerPrefs.SetInt("Num_6", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[6].SetActive(true);
        }
        if (Number == 7)
        {
            PlayerPrefs.SetInt("Num_7", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[7].SetActive(true);
        }
        if (Number == 8)
        {
            PlayerPrefs.SetInt("Num_8", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[8].SetActive(true);
        }
        if (Number == 9)
        {
            PlayerPrefs.SetInt("Num_9", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[9].SetActive(true);
        }
        if (Number == 10)
        {
            PlayerPrefs.SetInt("Num_10", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[10].SetActive(true);
        }
        if (Number == 11)
        {
            PlayerPrefs.SetInt("Num_11", 1);
            for (int i = 0; i < Number; i++)
            {
                canvasGO.WinImageSkin[i].SetActive(false);
            }
            canvasGO.WinImageSkin[11].SetActive(true);
        }
    }
    void FixedUpdate()
    {
        if (UpOpen)
        {
            if (transform.position.y < 20f)
            {
                transform.Translate(movement * Speed * Time.fixedDeltaTime);
            }
            else
            {
                UpOpenScale = true;
                UpOpen = false;
            }
        }
        if (UpOpenScale)
        {
            DeltaScale = Time.fixedDeltaTime * 5f;
            float Sc = Mathf.Lerp(transform.localScale.x, 0f, DeltaScale);
            if (transform.localScale.x > 0.1)
            {
                transform.localScale = new Vector3(Sc, Sc, Sc);
            }
            else
            {
                Destroy(gameObject);
                UpOpenScale = false;
            }
        }
    }
}