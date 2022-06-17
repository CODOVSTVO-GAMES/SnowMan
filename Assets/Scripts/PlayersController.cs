using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersController : MonoBehaviour
{
    private List<GameObject> SnowBallArray = new List<GameObject>();
    public GameObject[] SnowBallPrefab;
    public GameObject SnowTorPrefab;
    public GameObject SnowManText;
    private Material material;
    private GameObject[] SnowManArray = new GameObject[5];
    public int a = 0;
    private Transform Neck;
    private Color Color;
    private bool LeftLeg;
    private bool Trigger;
    public bool LegMove;
    private float time;
    private GameObject[] Road = new GameObject[2];
    public int TorCount;
    public Example example;
    private void Start()
    {
        Neck = GameObject.Find("Neck").transform;
        SnowManArray[0] = Instantiate(SnowBallPrefab[0], new Vector3(0, 0.95f, 0), Quaternion.identity, transform);
        SnowManArray[3] = Instantiate(SnowBallPrefab[2], new Vector3(-0.4f, 0.25f, 0.2f), Quaternion.identity, transform);
        SnowManArray[4] = Instantiate(SnowBallPrefab[2], new Vector3(0.4f, 0.25f, 0.2f), Quaternion.identity, transform);
        SnowManArray[1] = Instantiate(SnowBallPrefab[1], new Vector3(0, 1.85f, 0), Quaternion.identity, transform);
        GameObject FirstSnowBall = Instantiate(SnowTorPrefab, new Vector3(0, 2.4f, 0), Quaternion.Euler(90f, 0f, 0f), Neck);
        Destroy(FirstSnowBall.transform.GetChild(0).gameObject);
        SnowBallArray.Add(FirstSnowBall);
        SnowManArray[2] = Instantiate(SnowBallPrefab[PlayerPrefs.GetInt("CurrentButton") + 3], new Vector3(0.0f, 2.8f, 0.0f), Quaternion.Euler(0f, 90f, 0f), Neck);
        // SnowManArray[2] = Instantiate(SnowBallPrefab[2], new Vector3(0.202f, 2.8f, 0.509f), Quaternion.Euler(-73.366f, 61.99f, -76.946f), Neck);
        Camera.main.GetComponent<CameraMovement>().PlayerHead = SnowManArray[2];
        // for (int i = 0; i < 5; i++)
        // {
        //     // float Q = 1 + i * (SnowBallArray.Count * 0.01f);
        //     GameObject NextSnowBall = Instantiate(SnowTorPrefab, new Vector3(0, SnowBallArray[SnowBallArray.Count - 1].transform.position.y + 0.2f, 0), Quaternion.Euler(90f, 0f, 0f), Neck);
        //     Destroy(NextSnowBall.transform.GetChild(0).gameObject);
        //     // NextSnowBall.transform.localScale = new Vector3(Q, Q, Q);
        //     SnowBallArray.Add(NextSnowBall);
        //     SnowManArray[2].transform.position = new Vector3(SnowManArray[2].transform.position.x, SnowManArray[2].transform.position.y + 0.2f, SnowManArray[2].transform.position.z);
        //     // for (int a = 0; a < SnowBallArray.Count - 1; a++)
        //     // {
        //     //     SnowBallArray[a].transform.position = new Vector3(0, SnowBallArray[a].transform.position.y + 0.75f, 0);
        //     // }
        // }
        Road = GameObject.FindGameObjectsWithTag("Road");
        Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
    }
    public void AddSnowBall(Color color)
    {
        if (color == SnowManArray[0].GetComponent<Renderer>().material.color)
        {
            Camera.main.GetComponent<CameraMovement>().ZoomMinus();
            Vector3 rotation = new Vector3(90f, 0f, gameObject.GetComponent<PlayerMovement>().offset * 5f);
            GameObject SnowBall;
            if (SnowBallArray.Count != 0) SnowBall = Instantiate(SnowTorPrefab, new Vector3(SnowBallArray[SnowBallArray.Count - 1].transform.position.x, SnowBallArray[SnowBallArray.Count - 1].transform.position.y + 0.2f, SnowBallArray[SnowBallArray.Count - 1].transform.position.z), SnowBallArray[SnowBallArray.Count - 1].transform.rotation, Neck);
            else SnowBall = Instantiate(SnowTorPrefab, new Vector3(SnowManArray[1].transform.position.x, SnowManArray[2].transform.position.y - 0.2f, SnowManArray[1].transform.position.z), Quaternion.Euler(90f, 0f, 0f), Neck);
            if (material != null) SnowBall.GetComponent<Renderer>().material = material;
            SnowBallArray.Add(SnowBall);
            SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y + 0.2f, SnowManArray[2].transform.localPosition.z);
            Color = SnowBallArray[0].GetComponent<Renderer>().material.color;
            // ScaleDecrease();
            example.TriggerTaptic("medium");
            Instantiate(SnowManText, new Vector3(SnowManArray[1].transform.position.x + 0.5f, SnowManArray[1].transform.position.y, SnowManArray[1].transform.position.z - 0.6f), Quaternion.identity, Neck);
        }
        else
        {
            if (SnowBallArray.Count > 0)
            {
                Camera.main.GetComponent<CameraMovement>().ZoomPlus();
                Destroy(SnowBallArray[SnowBallArray.Count - 1]);
                SnowBallArray.RemoveAt(SnowBallArray.Count - 1);
                SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y - 0.2f, SnowManArray[2].transform.localPosition.z);
                // ScaleIncrease();
                example.TriggerTaptic("heavy");
            }
        }
        TorCount = SnowBallArray.Count;
        Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
    }
    public void ChangeColor(Color color, Material material)
    {
        this.material = material;
        for (int i = 0; i < SnowBallArray.Count; i++)
        {
            SnowBallArray[i].GetComponent<Renderer>().material.color = color;
        }
        foreach (GameObject GO in SnowManArray)
        {
            if (GO != SnowManArray[2]) GO.GetComponent<Renderer>().material.color = color;
            else 
            {
                GameObject.Find("Сфера.008").GetComponent<Renderer>().materials[9].color = color;
            }
        }
        foreach (GameObject GO in Road)
            GO.GetComponent<Renderer>().material.color = color;
    }
    private void FixedUpdate()
    {
        if (LegMove)
        {
            if (LeftLeg)
            {
                time += Time.fixedDeltaTime * 5f;
                float posZ = Mathf.Lerp(0.2f, 0f, time);
                SnowManArray[3].transform.localPosition = new Vector3(-0.4f, 0.25f, posZ);
                float posZ2 = Mathf.Lerp(0f, 0.2f, time);
                SnowManArray[4].transform.localPosition = new Vector3(0.4f, 0.25f, posZ2);
                if (time >= 1f)
                {
                    time = 0;
                    LeftLeg = false;
                }
            }
            if (!LeftLeg)
            {
                time += Time.fixedDeltaTime * 5f;
                float posZ = Mathf.Lerp(0f, 0.2f, time);
                SnowManArray[3].transform.localPosition = new Vector3(-0.4f, 0.25f, posZ);
                float posZ2 = Mathf.Lerp(0.2f, 0f, time);
                SnowManArray[4].transform.localPosition = new Vector3(0.4f, 0.25f, posZ2);
                if (time >= 1f)
                {
                    time = 0;
                    LeftLeg = true;
                }
            }
        }

    }
    public void Multiplier()
    {
        float data = Camera.main.GetComponent<GameManager>().Multiplier;
        float dataDelta = SnowBallArray.Count;
        data = (int)(SnowBallArray.Count * data);
        Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount((int)data);
        data = data - dataDelta;
        for (int i = 0; i < data; i++)
        {
            Vector3 rotation = new Vector3(90f, 0f, gameObject.GetComponent<PlayerMovement>().offset * 5f);
            GameObject SnowBall = Instantiate(SnowTorPrefab, new Vector3(SnowBallArray[SnowBallArray.Count - 1].transform.position.x, SnowBallArray[SnowBallArray.Count - 1].transform.position.y + 0.2f, SnowBallArray[SnowBallArray.Count - 1].transform.position.z), SnowBallArray[SnowBallArray.Count - 1].transform.rotation, Neck);
            if (material != null) SnowBall.GetComponent<Renderer>().material = material;
            SnowBallArray.Add(SnowBall);
            SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y + 0.2f, SnowManArray[2].transform.localPosition.z);
            Color = SnowBallArray[0].GetComponent<Renderer>().material.color;
        }
        Camera.main.GetComponent<CameraMovement>().FinishTransformCamera(SnowBallArray.Count);
    }
    public void ContactObstacles()
    {
        if (!Trigger)
        {
            Trigger = true;
            if (SnowBallArray.Count > 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    Camera.main.GetComponent<CameraMovement>().ZoomPlus();
                    Destroy(SnowBallArray[SnowBallArray.Count - 1]);
                    SnowBallArray.RemoveAt(SnowBallArray.Count - 1);
                    SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y - 0.2f, SnowManArray[2].transform.localPosition.z);
                    example.TriggerTaptic("heavy");
                    Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (SnowBallArray.Count > 0)
                    {
                        Camera.main.GetComponent<CameraMovement>().ZoomPlus();
                        Destroy(SnowBallArray[SnowBallArray.Count - 1]);
                        SnowBallArray.RemoveAt(SnowBallArray.Count - 1);
                        SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y - 0.2f, SnowManArray[2].transform.localPosition.z);
                        example.TriggerTaptic("heavy");
                        Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
                    }
                }
            }
            Invoke("UnTrigger", 1f);
        }
    }
    void UnTrigger()
    {
        Trigger = false;
    }
    public void ContactUpDowners()
    {
        if (!Trigger)
        {
            Trigger = true;
            if (SnowBallArray.Count > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    Camera.main.GetComponent<CameraMovement>().ZoomPlus();
                    Destroy(SnowBallArray[SnowBallArray.Count - 1]);
                    SnowBallArray.RemoveAt(SnowBallArray.Count - 1);
                    SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y - 0.2f, SnowManArray[2].transform.localPosition.z);
                    example.TriggerTaptic("heavy");
                    Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (SnowBallArray.Count > 0)
                    {
                        Camera.main.GetComponent<CameraMovement>().ZoomPlus();
                        Destroy(SnowBallArray[SnowBallArray.Count - 1]);
                        SnowBallArray.RemoveAt(SnowBallArray.Count - 1);
                        SnowManArray[2].transform.localPosition = new Vector3(SnowManArray[2].transform.localPosition.x, SnowManArray[2].transform.localPosition.y - 0.2f, SnowManArray[2].transform.localPosition.z);
                        example.TriggerTaptic("heavy");
                        Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
                    }
                }
            }
            Invoke("UnTrigger", 1f);
        }
    }
    // private void ScaleDecrease()
    // {
    //     float q = SnowBallArray.Count;
    //     q = 1 - q / 60;
    //     for (int a = 0; a < SnowBallArray.Count - 1; a++)
    //     {
    //         SnowBallArray[a].transform.position = new Vector3(SnowBallArray[a].transform.position.x, 0.75f + SnowBallArray[a].transform.position.y, SnowBallArray[a].transform.position.z);
    //     }
    //     for (int i = 0; i < SnowBallArray.Count; i++)
    //     {
    //         float Q = q + i * (SnowBallArray.Count * 0.005f) * 0.5f;
    //         SnowBallArray[i].transform.localScale = new Vector3(Q, Q, Q);
    //         if (i != SnowBallArray.Count - 1) SnowBallArray[i].transform.position = new Vector3(SnowBallArray[i].transform.position.x, SnowBallArray[i].transform.position.y + i * 0.02f, SnowBallArray[i].transform.position.z);
    //         else SnowBallArray[i].transform.position = new Vector3(SnowBallArray[i].transform.position.x, SnowBallArray[i].transform.position.y + i * (SnowBallArray.Count * 0.01f) * 0.01f, SnowBallArray[i].transform.position.z);
    //     }
    // }
    // private void ScaleIncrease()
    // {
    //     float q = SnowBallArray.Count;
    //     q = 1 - q / 60 + (q / 50);
    //     for (int i = 0; i < SnowBallArray.Count; i++)
    //     {
    //         SnowBallArray[i].transform.position = new Vector3(SnowBallArray[i].transform.position.x, SnowBallArray[i].transform.position.y - 0.75f, SnowBallArray[i].transform.position.z);
    //     }
    //     for (int i = 0; i < SnowBallArray.Count; i++)
    //     {
    //         float Q = q + i * (SnowBallArray.Count * 0.01f) * 0.5f;
    //         SnowBallArray[i].transform.localScale = new Vector3(Q, Q, Q);
    //         if (i != SnowBallArray.Count - 1) SnowBallArray[i].transform.position = new Vector3(SnowBallArray[i].transform.position.x, SnowBallArray[i].transform.position.y - i * 0.02f, SnowBallArray[i].transform.position.z);
    //         else SnowBallArray[i].transform.position = new Vector3(SnowBallArray[i].transform.position.x, SnowBallArray[i].transform.position.y - i * (SnowBallArray.Count * 0.01f) * 0.1f, SnowBallArray[i].transform.position.z);
    //     }
    // }
}