using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGO : MonoBehaviour
{
    public GameObject Diamond;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0)
        {
            Camera.main.GetComponent<GameManager>().FinishDiam(Diamond);
        }
    }
    public void FinishAnimation()
    {
        transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
    }
}