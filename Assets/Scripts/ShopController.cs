using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using GoogleMobileAds.Api;
// using GoogleMobileAds.Common;
// using AppodealAds.Unity.Api;
// using AppodealAds.Unity.Common;
// using Firebase;
// using Firebase.Analytics;
public class ShopController : MonoBehaviour//, IRewardedVideoAdListener
{
    public Text Deamond;
    public GameObject[] Buttons;
    public Sprite[] Sprites;
    public GameObject[] Headers;
    public GameObject ConfirmButton;
    public GameObject AdButton;
    private int[] Costs = new int[] { 0, 100, 200, 400, 800, 1600 };
    private int Buffer;
    private GameObject Head;
    private string APP_KEY = "fd5361dee7ebad22531938ec705c4c2267021fd43a27f1f7";
    // private RewardedAd rewardedAd;
    // private string adUnitId = "ca-app-pub-9779951738743946/1702386953";
    void Start()
    {
        // Initialized();
        FirstLaunch();
        ManualUpdate();
        CheckButtons();
        Head = Instantiate(Headers[PlayerPrefs.GetInt("CurrentButton")], new Vector3(0f, -2f, -12.5f), Quaternion.Euler(0f, -60f, 0f));
        ConfirmButton.SetActive(false);
        AdButton.SetActive(false);
        // for (int i = 1; i < 6; i++)
        // {
        //     PlayerPrefs.SetInt("Button_" + i.ToString(), 0);
        // }
        // this.rewardedAd = new RewardedAd(adUnitId);
        // this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // AdRequest request = new AdRequest.Builder().Build();
        // this.rewardedAd.LoadAd(request);
    }
    // void Initialized()
    // {
    //     Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
    //     Appodeal.setRewardedVideoCallbacks(this);
    // }
    // public void ShowRewarded()
    // {
    //     if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
    //     {
    //         Appodeal.show(Appodeal.REWARDED_VIDEO);
    //     }
    // }

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
    //     PlayerPrefs.SetInt("Button_" + Buffer.ToString(), 1);
    //     PlayerPrefs.SetInt("CurrentButton", Buffer);
    //     CheckButtons();
    //     ManualUpdate();
    //     if (Head != null) Destroy(Head);
    //     Head = Instantiate(Headers[Buffer], new Vector3(0f, -2f, -12.5f), Quaternion.Euler(0f, -60f, 0f));
    //     ConfirmButton.SetActive(false);
    //     AdButton.SetActive(false);
    //     Firebase.Analytics.FirebaseAnalytics.LogEvent("AdSkin_" + Buffer.ToString());
    // }
    // public void onRewardedVideoExpired()
    // {
    //     print("Video expired");
    // }
    // #endregion
    // public void HandleUserEarnedReward(object sender, Reward args)
    // {
    //     string type = args.Type;
    //     double amount = args.Amount;
    //     MonoBehaviour.print(
    //         "HandleRewardedAdRewarded event received for "
    //                     + amount.ToString() + " " + type);
    //     PlayerPrefs.SetInt("Button_" + Buffer.ToString(), 1);
    //     PlayerPrefs.SetInt("CurrentButton", Buffer);
    //     CheckButtons();
    //     ManualUpdate();
    //     if (Head != null) Destroy(Head);
    //     Head = Instantiate(Headers[Buffer], new Vector3(0f, -2f, -12.5f), Quaternion.Euler(0f, -60f, 0f));
    //     ConfirmButton.SetActive(false);
    //     AdButton.SetActive(false);
    //     Firebase.Analytics.FirebaseAnalytics.LogEvent("AdSkin_" + Buffer.ToString());
    //     AdRequest request = new AdRequest.Builder().Build();
    //     this.rewardedAd.LoadAd(request);
    // }
    // void WatchAd()
    // {
    //     if (this.rewardedAd.IsLoaded())
    //     {
    //         this.rewardedAd.Show();
    //     }
    // }
    void FirstLaunch()
    {
        if (PlayerPrefs.GetInt("FirstLaunch") == 0)
        {
            PlayerPrefs.SetInt("Button_0", 1);

            PlayerPrefs.SetInt("FirstLaunch", 1);
        }
    }
    void ManualUpdate()
    {
        Deamond.text = PlayerPrefs.GetInt("Gems").ToString();
    }
    void CheckButtons()
    {
        for (int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.GetInt("Button_" + i.ToString()) == 1)
            {
                Buttons[i].gameObject.GetComponent<Image>().sprite = Sprites[1];
            }
        }
        Buttons[PlayerPrefs.GetInt("CurrentButton")].GetComponent<Image>().sprite = Sprites[2];
    }
    public void ChoiceSkin(int Number)
    {
        if (PlayerPrefs.GetInt("Button_" + Number.ToString()) == 0)
        {
            AdButton.SetActive(true);
            ConfirmButton.SetActive(true);
            ConfirmButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = Costs[Number].ToString();
            CheckButtons();
            Buffer = Number;
        }
        else if (PlayerPrefs.GetInt("Button_" + Number.ToString()) == 1)
        {
            ConfirmButton.SetActive(false);
            AdButton.SetActive(false);
            PlayerPrefs.SetInt("CurrentButton", Number);
            CheckButtons();
            if (Head != null) Destroy(Head);
            Head = Instantiate(Headers[Number], new Vector3(0f, -2f, -12.5f), Quaternion.Euler(0f, -60f, 0f));
        }
    }
    public void ButtonUnlock()
    {
        if (PlayerPrefs.GetInt("Gems") - Int32.Parse(ConfirmButton.transform.GetChild(0).gameObject.GetComponent<Text>().text) >= 0)
        {
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") - Int32.Parse(ConfirmButton.transform.GetChild(0).gameObject.GetComponent<Text>().text));
            PlayerPrefs.SetInt("Button_" + Buffer.ToString(), 1);
            PlayerPrefs.SetInt("CurrentButton", Buffer);
            CheckButtons();
            ManualUpdate();
            if (Head != null) Destroy(Head);
            Head = Instantiate(Headers[Buffer], new Vector3(0f, -2f, -12.5f), Quaternion.Euler(0f, -60f, 0f));
            ConfirmButton.SetActive(false);
            AdButton.SetActive(false);
            // Firebase.Analytics.FirebaseAnalytics.LogEvent("BuySkin_" + Buffer.ToString());
        }
    }
    public void AdUnlock()
    {
        // ShowRewarded();
        PlayerPrefs.SetInt("Button_" + Buffer.ToString(), 1);
        PlayerPrefs.SetInt("CurrentButton", Buffer);
        CheckButtons();
        ManualUpdate();
        if (Head != null) Destroy(Head);
        Head = Instantiate(Headers[Buffer], new Vector3(0f, -2f, -12.5f), Quaternion.Euler(0f, -60f, 0f));
        ConfirmButton.SetActive(false);
        AdButton.SetActive(false);
    }
}