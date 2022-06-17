using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersControllerGemsLevel : MonoBehaviour
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
        for (int i = 0; i < 9; i++)
        {
            GameObject NextSnowBall = Instantiate(SnowTorPrefab, new Vector3(0, SnowBallArray[SnowBallArray.Count - 1].transform.position.y + 0.2f, 0), Quaternion.Euler(90f, 0f, 0f), Neck);
            Destroy(NextSnowBall.transform.GetChild(0).gameObject);
            SnowBallArray.Add(NextSnowBall);
            SnowManArray[2].transform.position = new Vector3(SnowManArray[2].transform.position.x, SnowManArray[2].transform.position.y + 0.2f, SnowManArray[2].transform.position.z);
            Camera.main.GetComponent<CameraMovement>().ZoomMinus();
        }
        Road = GameObject.FindGameObjectsWithTag("Road");
        Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCount(SnowBallArray.Count);
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
}
