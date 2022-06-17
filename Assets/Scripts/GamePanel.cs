using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GamePanel : MonoBehaviour
{
    public GameObject Count;

    public void ChangeCount(int count)
    {
        if (SceneManager.GetActiveScene().buildIndex % 5 != 0) Count.GetComponent<TextMeshProUGUI>().text = count.ToString();
    }
    public void ChangeCountString(string count)
    {
        if (SceneManager.GetActiveScene().buildIndex % 5 != 0) Count.GetComponent<TextMeshProUGUI>().text = count;
    }
}