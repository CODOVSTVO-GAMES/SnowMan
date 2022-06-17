using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollections : MonoBehaviour
{
    public bool Trigger;
    private float offset;
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "SnowBall":
                transform.parent.gameObject.GetComponent<PlayersController>().AddSnowBall(other.gameObject.GetComponent<Renderer>().material.color);
                Destroy(other.gameObject);
                break;
            case "Change":
                if (other.gameObject.transform.parent.childCount == 2)
                {
                    Destroy(other.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<BoxCollider>());
                    Destroy(other.gameObject.transform.parent.GetChild(1).gameObject.GetComponent<BoxCollider>());
                } else Destroy(other.gameObject.GetComponent<BoxCollider>());
                transform.parent.gameObject.GetComponent<PlayersController>().ChangeColor(other.gameObject.GetComponent<Renderer>().material.color, other.gameObject.GetComponent<Renderer>().material);
                break;
            case "Finish":
                Destroy(other.gameObject.GetComponent<BoxCollider>());
                other.gameObject.GetComponent<FinishGO>().FinishAnimation();
                if (SceneManager.GetActiveScene().buildIndex % 5 == 0) Camera.main.GetComponent<GameManager>().FinishGame();
                break;
            case "PostFinish":
                Destroy(other.gameObject.GetComponent<BoxCollider>());
                Camera.main.GetComponent<GameManager>().Finish();
                Camera.main.GetComponent<GameManager>().GamePanel.GetComponent<GamePanel>().ChangeCountString(Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayersController>().TorCount.ToString() + " X" + Camera.main.GetComponent<GameManager>().Multiplier.ToString());
                Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayerMovement>().FinishBoost();
                Invoke("FinishMultiplier", 1f);
                break;
            case "FinishDoor":
                Destroy(other.gameObject.GetComponent<BoxCollider>());
                other.gameObject.GetComponent<FinishMultiplierStageDoor>().Collision();
                break;
            case "TestPresent":
                Destroy(other.gameObject.GetComponent<BoxCollider>());
                Destroy(other.transform.GetChild(0).gameObject);
                other.gameObject.transform.parent.gameObject.GetComponent<FinishMultiplier>().Presents[Int32.Parse(other.gameObject.name.Substring(9))].GetComponent<BoxController>().Open();
                break;
            case "DownPresent":
                Camera.main.GetComponent<GameManager>().FinishGame();
                break;
            case "Deamond":
                Destroy(other.gameObject);
                Camera.main.GetComponent<GameManager>().GemDeamond();
                break;
            case "ColliderScale":
                Destroy(other.gameObject.GetComponent<BoxCollider>());
                other.gameObject.transform.parent.gameObject.GetComponent<FinishMultiplier>().Gifts[Int32.Parse(other.gameObject.name.Substring(14))].GetComponent<GiftController>().DeltaScale();
                break;
            case "Obstacles":
                BoxCollider[] Objs = other.gameObject.GetComponents<BoxCollider>();
                foreach (BoxCollider obj in Objs) Destroy(obj);
                Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayerMovement>().ObstRot();
                Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayersController>().ContactObstacles();
                break;
            case "Rotator":
                Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayerMovement>().ObstRot();
                Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayersController>().ContactUpDowners();
                break;
        }
    }
    void FinishMultiplier()
    {
        Camera.main.GetComponent<GameManager>().Player.GetComponent<PlayersController>().Multiplier();
    }
}