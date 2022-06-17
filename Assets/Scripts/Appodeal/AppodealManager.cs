using UnityEngine;
// using AppodealAds.Unity.Api;
// using AppodealAds.Unity.Common;
public class AppodealManager : MonoBehaviour//, IRewardedVideoAdListener
{
    private string APP_KEY = "fd5361dee7ebad22531938ec705c4c2267021fd43a27f1f7";
    bool consentValue = true;
    // void Start()
    // {
    //     Initialized();
    // }
    void Initialized()
    {
        // Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        // Appodeal.initialize(APP_KEY, Appodeal.BANNER, consentValue);
        // Appodeal.setRewardedVideoCallbacks(this);
        // Appodeal.show(Appodeal.BANNER_BOTTOM);
    }
    public void ShowInterstitial()
    {
        // if (Appodeal.canShow(Appodeal.INTERSTITIAL))
        // {
        //     Appodeal.show(Appodeal.INTERSTITIAL);
        // }
    }
    public void ShowRewarded()
    {
        // if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        // {
        //     Appodeal.show(Appodeal.REWARDED_VIDEO);
        // }
    }
    
    // #region Rewarded Video callback handlers
    // public void onRewardedVideoLoaded(bool isPrecache)
    // {
    //     print("Video loaded");
    // }
    // public void onRewardedVideoFailedToLoad()
    // {
    //     print("Video failed");
    // }
    // public void onRewardedVideoShowFailed()
    // {
    //     print("Video show failed");
    // }
    // public void onRewardedVideoShown()
    // {
    //     print("Video shown");
    // }
    // public void onRewardedVideoClicked()
    // {
    //     print("Video clicked");
    // }
    // public void onRewardedVideoClosed(bool finished)
    // {
    //     print("Video closed");
    // }
    // public void onRewardedVideoFinished(double amount, string name)
    // {
    //     // PlayerPrefs.SetInt("LevelStart", 1);
    //     // gameObject.GetComponent<GameManager>().GamePanel.transform.parent.gameObject.GetComponent<LevelManager>().OpenLevel();
    //     gameObject.GetComponent<GameManager>().GemsX();
    // }
    // public void onRewardedVideoExpired()
    // {
    //     print("Video expired");
    // }
    // #endregion
}