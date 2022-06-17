using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Counter : MonoBehaviour
{
    public GameObject Passed_2;
    public GameObject Passed_1;
    public GameObject Current;
    public GameObject Upcoming_1;
    public GameObject Upcoming_2;
    public Text GemsText;
    private int Scene;
    void Start()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
        if (Scene < 2)
        {
            Passed_1.SetActive(false);
            Passed_2.SetActive(false);
        }
        else
        {
            if (Scene < 3)
            {
                Passed_2.SetActive(false);
                Passed_1.transform.GetChild(0).gameObject.GetComponent<Text>().text = (Scene - 1).ToString();
            }
            else
            {
                Passed_2.transform.GetChild(0).gameObject.GetComponent<Text>().text = (Scene - 2).ToString();
                Passed_1.transform.GetChild(0).gameObject.GetComponent<Text>().text = (Scene - 1).ToString();
            }
        }
        Current.transform.GetChild(0).gameObject.GetComponent<Text>().text = Scene.ToString();
        Upcoming_1.transform.GetChild(0).gameObject.GetComponent<Text>().text = (Scene + 1).ToString();
        Upcoming_2.transform.GetChild(0).gameObject.GetComponent<Text>().text = (Scene + 2).ToString();
    }
}
