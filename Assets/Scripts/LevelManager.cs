using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelStart", 1);
        float RandomNumber = Random.Range( 1, 11);
        if (RandomNumber >= 1 && RandomNumber <= 7) Camera.main.GetComponent<AppodealManager>().ShowInterstitial();
        // if (RandomNumber >= 1 && RandomNumber <= 6) Camera.main.GetComponent<MobAdsInterstitial>().LoadInterstitial();
        Invoke("OpenLevel", 0.1f);
    }
    public void NextHomeLevel()
    {
        PlayerPrefs.SetInt("LevelStart", 0);
        float RandomNumber = Random.Range( 1, 11);
        if (RandomNumber >= 1 && RandomNumber <= 7) Camera.main.GetComponent<AppodealManager>().ShowInterstitial();
        // if (RandomNumber >= 1 && RandomNumber <= 6) Camera.main.GetComponent<MobAdsInterstitial>().LoadInterstitial();
        Invoke("OpenLevel", 0.1f);
    }
    public void OpenLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex < 20)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(1);
    }
    public void NextOpenLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level") + 1);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void StartLevel()
    {
        Camera.main.GetComponent<GameManager>().GamePanel.transform.parent.gameObject.GetComponent<CanvasGO>().GoToStart.SetActive(false);
        Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayerMovement>().DontStart = true;
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0) Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayersControllerGemsLevel>().LegMove = true;
        else Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayersController>().LegMove = true;
        PlayerPrefs.SetInt("LevelStart", 0);
        Invoke("StartFirebase", 1f);
    }
    void StartFirebase()
    {
        Camera.main.GetComponent<GameManager>().StartFirebase();
    }
    public void RewardedAd()
    {
        Camera.main.GetComponent<AppodealManager>().ShowRewarded();
        // Camera.main.GetComponent<MobAdsRewarded>().WatchAd();
    }
}