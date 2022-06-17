using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDiamond : MonoBehaviour
{
    GameObject CoinsPlus;
    GameObject Coins;
    Vector3 CoinsPlusV;
    Vector3 CoinsV;
    float Anim;
    bool Trigger = false;
    float x;
    float y;
    int AnimationStage;
    bool TriggerMoney;
    void Start()
    {
        CoinsPlus = Camera.main.GetComponent<GameManager>().GamePanel.transform.parent.gameObject.GetComponent<CanvasGO>().ButtonX;
        Coins = Camera.main.GetComponent<GameManager>().GamePanel.transform.parent.gameObject.GetComponent<CanvasGO>().GemsX;
        CoinsPlusV = CoinsPlus.GetComponent<RectTransform>().position;
        CoinsV = Coins.GetComponent<RectTransform>().position;
        Trigger = true;
    }
    void FixedUpdate()
    {
        if (Trigger)
        {
            Anim += Time.deltaTime * 2f;
            x = Mathf.Lerp(CoinsPlusV.x, CoinsV.x, Anim);
            y = Mathf.Lerp(CoinsPlusV.y, CoinsV.y, Anim);
            this.GetComponent<RectTransform>().position = new Vector3(x, y, this.GetComponent<RectTransform>().position.z);
            if (this.GetComponent<RectTransform>().position.y == CoinsV.y)
            {
                Anim = 0;
                Trigger = false;
                Destroy(this.gameObject);
            }
        }
    }
}
