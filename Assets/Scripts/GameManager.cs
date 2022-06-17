using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using Firebase;
// using Firebase.Analytics;

public class GameManager : MonoBehaviour
{
    private GameObject WinPanel;
    private GameObject DeadPanel;
    private int Gems;
    private int InitialGems;
    public GameObject GamePanel;
    public GameObject Player;
    public float Multiplier;
    public int Scene;
    public GameObject FinishDiamond;
    void Awake()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
        WinPanel = GameObject.FindGameObjectWithTag("WinPanel");
        DeadPanel = GameObject.FindGameObjectWithTag("DeadPanel");
        GamePanel = GameObject.FindGameObjectWithTag("GamePanel");
        Player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerPrefs.GetInt("LevelStart") == 1)
        {
            GamePanel.transform.parent.gameObject.GetComponent<CanvasGO>().GoToStart.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex % 5 == 0) Player.GetComponent<PlayersControllerGemsLevel>().LegMove = true;
            else Player.GetComponent<PlayersController>().LegMove = true;
            Invoke("LevelStart0", 1f);
            StartFirebase();
        }
        WinPanel.SetActive(false);
        DeadPanel.SetActive(false);
        Gems = PlayerPrefs.GetInt("Gems");
        InitialGems = PlayerPrefs.GetInt("Gems");
        GamePanel.GetComponent<Counter>().GemsText.text = Gems.ToString();
    }
    void LevelStart0()
    {
        PlayerPrefs.SetInt("LevelStart", 0);
    }
    public void Finish()
    {
        Player.GetComponent<PlayerMovement>().MovingToTheSidesB = false;
        Camera.main.GetComponent<CameraMovement>().FinishTransformCamera(Player.GetComponent<PlayersController>().TorCount);
    }
    public void StartFirebase()
    {
        // Firebase.Analytics.FirebaseAnalytics.LogEvent("StartLevel_" + Scene.ToString());
    }
    public void FinishGame()
    {
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0) Gems += 10;
        GamePanel.GetComponent<Counter>().GemsText.text = Gems.ToString();
        // Player.GetComponent<PlayerMovement>().RotationFinish();
        Player.GetComponent<PlayerMovement>().MovingForwardB = false;
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0)
        {
            Player.GetComponent<PlayersControllerGemsLevel>().LegMove = false;
            Player.GetComponent<PlayerMovement>().DontStart = false;
            Player.GetComponent<PlayersControllerGemsLevel>().example.TriggerTaptic("default");
            FinishDiamond.GetComponent<FinishScale>().DeltaScale();
        }
        else
        {
            Player.GetComponent<PlayersController>().LegMove = false;
            gameObject.GetComponent<CameraMovement>().Multiplier();
        }
        Invoke("FinishScene", 1f);
        PlayerPrefs.SetInt("Gems", Gems);
    }
    void FinishScene()
    {
        // Firebase.Analytics.FirebaseAnalytics.LogEvent("EndLevel_" + Scene.ToString());
        WinPanel.SetActive(true);
        GamePanel.SetActive(false);
        if (Scene < 20) PlayerPrefs.SetInt("Level", Scene);
        else PlayerPrefs.SetInt("Level", 1);
    }
    public void GemDeamond()
    {
        Gems++;
        GamePanel.GetComponent<Counter>().GemsText.text = Gems.ToString();
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0) Player.GetComponent<PlayersControllerGemsLevel>().example.TriggerTaptic("medium");
        else Player.GetComponent<PlayersController>().example.TriggerTaptic("medium");
    }
    public void GemsX()
    {
        InitialGems = Gems - InitialGems;
        Gems += InitialGems;
        PlayerPrefs.SetInt("Gems", Gems);
        GamePanel.GetComponent<Counter>().GemsText.text = Gems.ToString();
        // WinPanel.transform.parent.gameObject.GetComponent<AnimateDeamondController>().StartAnimate();
    }
    public void FinishDiam(GameObject GO)
    {
        FinishDiamond = GO;
    }
}