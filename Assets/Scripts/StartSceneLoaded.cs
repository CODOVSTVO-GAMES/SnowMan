using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneLoaded : MonoBehaviour
{
    void Start()
    {
        Invoke("GetOpenLevel", 5f);
    }
    void GetOpenLevel()
    {
        // if(PlayerPrefs.GetInt("Level") == 0) PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level") + 1);
        // SceneManager.LoadScene(1);
    }
    public void URL()
    {
        Application.OpenURL("https://codovstvo.ru/snowman.html");
    }
}