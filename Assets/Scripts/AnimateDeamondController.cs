using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDeamondController : MonoBehaviour
{
    public GameObject Coins;
    public int AnimationStage;
    public GameObject CoinsPrefab;
    public void StartAnimate()
    {
        AnimationStage = 10;
        Animate();
    }
    void Animate()
    {
        if (AnimationStage > 0)
        {
            AnimationStage--;
            Invoke("SpawnAnimate", 0.1f);
        }
    }
    void SpawnAnimate()
    {
        Instantiate(CoinsPrefab, Coins.gameObject.GetComponent<RectTransform>().GetChild(0).position, Quaternion.identity, Camera.main.GetComponent<GameManager>().GamePanel.transform.parent.gameObject.GetComponent<CanvasGO>().ButtonX.transform);
        Animate();
    }
}